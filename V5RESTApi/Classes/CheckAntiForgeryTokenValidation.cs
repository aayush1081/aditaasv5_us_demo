using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace aditaas_v5.Classes
{
    public class CheckAntiForgeryTokenValidation : IFilterProvider
    {
        public int Order => 999;
        public void OnProvidersExecuted(FilterProviderContext context) { }
        public void OnProvidersExecuting(FilterProviderContext context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.ActionContext.ActionDescriptor.FilterDescriptors != null)
            {
                var headers = context.ActionContext.HttpContext.Request.Headers;
                if (headers.ContainsKey("FROM-WINSERVICE"))
                {
                    var tokenval = headers.Where(h => h.Key == "X-XSRF-TOKEN").FirstOrDefault().Value.FirstOrDefault();

                    var istokenValid = GlobalClass.antiforgtoekn.Where(a => a == tokenval).Any();
                    if (!istokenValid) return;

                    var header = headers["FROM-WINSERVICE"].FirstOrDefault();
                    if (header.StartsWith("WinServiceToken", StringComparison.OrdinalIgnoreCase))
                    {
                        var FilterDescriptor = new FilterDescriptor(SkipAntiforgeryPolicy.Instance, FilterScope.Last);
                        var filterItem = new FilterItem(FilterDescriptor, SkipAntiforgeryPolicy.Instance);
                        context.Results.Add(filterItem);
                    }
                }
            }
        }

        // a dummy IAntiforgeryPolicy
        class SkipAntiforgeryPolicy : IAntiforgeryPolicy, IAsyncAuthorizationFilter
        {
            // a singleton 
            public static SkipAntiforgeryPolicy Instance = new SkipAntiforgeryPolicy();
            public Task OnAuthorizationAsync(AuthorizationFilterContext context) => Task.CompletedTask;
        }
    }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //public class CustValidateAntiForgeryTokenAttribute : Attribute, IFilterFactory, IOrderedFilter
    //{
    //    public bool IsReusable => true;

    //    public int Order { get; set; } = 1000;

    //    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    //    {
    //        return serviceProvider.GetRequiredService<CustValidateAntiforgeryTokenAuthorizationFilter>();
    //    }
    //}

    //internal class CustValidateAntiforgeryTokenAuthorizationFilter : IAsyncAuthorizationFilter, IAntiforgeryPolicy
    //{
    //    private readonly IAntiforgery _antiforgery;
    //    private readonly ILogger _logger;

    //    public CustValidateAntiforgeryTokenAuthorizationFilter(IAntiforgery antiforgery, ILoggerFactory loggerFactory)
    //    {
    //        if (antiforgery == null)
    //        {
    //            throw new ArgumentNullException(nameof(antiforgery));
    //        }

    //        _antiforgery = antiforgery;
    //        _logger = loggerFactory.CreateLogger(GetType());
    //    }

    //    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentNullException(nameof(context));
    //        }

    //        if (!context.IsEffectivePolicy<IAntiforgeryPolicy>(this))
    //        {
    //            _logger.NotMostEffectiveFilter(typeof(IAntiforgeryPolicy));
    //            return;
    //        }

    //        if (ShouldValidate(context))
    //        {
    //            try
    //            {
    //                await _antiforgery.ValidateRequestAsync(context.HttpContext);
    //            }
    //            catch (AntiforgeryValidationException exception)
    //            {
    //                _logger.AntiforgeryTokenInvalid(exception.Message, exception);
    //                context.Result = new AntiforgeryValidationFailedResult();
    //            }
    //        }
    //    }

    //    protected virtual bool ShouldValidate(AuthorizationFilterContext context)
    //    {
    //        if (context == null)
    //        {
    //            throw new ArgumentNullException(nameof(context));
    //        }

    //        return true;
    //    }
    //}
    //internal static class MvcViewFeaturesLoggerExtensions
    //{
    //    private static readonly Action<ILogger, Type, Exception> _notMostEffectiveFilter;
    //    private static readonly Action<ILogger, string, Exception> _antiforgeryTokenInvalid;

    //    static MvcViewFeaturesLoggerExtensions()
    //    {
    //        _notMostEffectiveFilter = LoggerMessage.Define<Type>(
    //            LogLevel.Trace,
    //            1,
    //            "Skipping the execution of current filter as its not the most effective filter implementing the policy {FilterPolicy}.");

    //        _antiforgeryTokenInvalid = LoggerMessage.Define<string>(
    //           LogLevel.Information,
    //           1,
    //           "Antiforgery token validation failed. {Message}");
    //    }

    //    public static void NotMostEffectiveFilter(this ILogger logger, Type policyType)
    //    {
    //        _notMostEffectiveFilter(logger, policyType, null);
    //    }

    //    public static void AntiforgeryTokenInvalid(this ILogger logger, string message, Exception exception)
    //    {
    //        _antiforgeryTokenInvalid(logger, message, exception);
    //    }
    //}

    //public class AntiforgeryFilterClass : IAsyncAuthorizationFilter
    //{
    //    private readonly IAntiforgery antiforgery;

    //    public AntiforgeryFilterClass(IAntiforgery antiforgery)
    //    {
    //        this.antiforgery = antiforgery;
    //    }

    //    public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //    {
    //        return antiforgery.ValidateRequestAsync(context.HttpContext);
    //    }
    //}

}
