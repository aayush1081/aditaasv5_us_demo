using aditaas_v5.Classes;
using aditaas_v5.Classes.Notification;
using aditaas_v5.Models;
using AutoMapper;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
//using AutoMapper;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Text;

namespace aditaas_v5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
            var originlist = configuration.GetSection("AllowOrigin").GetValue<string>("OriginList");

            var arroriginlist = originlist.Split(",");
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins(arroriginlist)
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();

                //builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
            }));

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IFilterProvider, CheckAntiForgeryTokenValidation>());

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new ValidateAntiForgeryTokenAttribute());
                //options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressMapClientErrors = true;
            });

            //https://www.blinkingcaret.com/2018/11/29/asp-net-core-web-api-antiforgery/
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });

            var str_dbConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkSqlServer().AddDbContext<aditaas_v5Context>(options => options.UseSqlServer(str_dbConnection, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                sqlOptions.CommandTimeout(3600);
                //options.EnableSensitiveDataLogging(true);
            }));

            var AppSettings = configuration.GetSection("AppSettings");
            #region code to handle session in load balancer          
            var redisConn = configuration.GetConnectionString("RedisConnection");
            var RedisAppName = AppSettings.GetValue<string>("RedisAppName");
            //services.AddDataProtection().PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(redisConn), "DataProtection-Keys").SetApplicationName("aditaasdemo");
            var Blobstorage = configuration.GetSection("Blobstorage");

            var DataProtectionAzureConStr = Blobstorage.GetValue<string>("ConnectionString");
            var DataProtectionContainerName = Blobstorage.GetValue<string>("ContainerName");
            var DataProtectionBlobName = Blobstorage.GetValue<string>("DataProtectionBlobName");
            
            TokenCredential credential = new ClientSecretCredential("6180208d-4246-468f-9eee-53fb042edd91", "96a4e23c-37f7-4f64-baa0-f7cb52ca57b9", "99Q8Q~reJ6GjaltCWKWIHtchliv~T4a1NLaZ.aZQ");
            IKeyEncryptionKeyResolver keyResolver = new KeyResolver(credential);

            services.AddDataProtection()
                .SetApplicationName(RedisAppName).PersistKeysToAzureBlobStorage(DataProtectionAzureConStr, DataProtectionContainerName, DataProtectionBlobName);
            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = redisConn + ",defaultDatabase=0";
                o.InstanceName = RedisAppName + "cache";
            });

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(30);
            //    options.Cookie.Name = "AppAditaasCSI";
            //});
            #endregion

            //GlobalClass.Set_EmailSetting_Value();
            GlobalClass.KendoChartExportApi = AppSettings.GetValue<string>("KendoChartExportApi");

            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(30);
            })
            .AddStackExchangeRedis(redisConn + ",defaultDatabase=2", options =>
            {
                options.Configuration.ChannelPrefix = RedisAppName + "SignalR";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiForgery)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            /*else
            {
                app.UseHsts();
            }*/
            app.UseDeveloperExceptionPage();
            //app.UseHttpsRedirection();

            app.UseCors("MyPolicy");
          
            //app.UseMvc();
            //app.Use(next => context =>
            //{
            //    if (context.Request.Path.Value.IndexOf("/api", StringComparison.OrdinalIgnoreCase) != -1)
            //    {
            //        var tokens = antiForgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
            //            new CookieOptions() { HttpOnly = false });
            //    }
            //    return next(context);
            //});

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });

            //app.UseSignalR(route =>
            //{
            //    route.MapHub<NotificationHub>("/notificationHub");
            //});


            GlobalClass.Services = app.ApplicationServices;

        }
    }
}
