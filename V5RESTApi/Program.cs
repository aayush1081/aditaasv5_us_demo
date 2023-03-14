using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace aditaas_v5
{
    public class Program
    {
        private static CancellationTokenSource cancelTokenSource = new System.Threading.CancellationTokenSource();
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            host.RunAsync(cancelTokenSource.Token).GetAwaiter().GetResult();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //NOSONAR
                .ConfigureLogging(logger => { //NOSONAR
                    logger.AddConsole(x => x.TimestampFormat = "[yyyy.MM.dd HH:mm:ss] "); //NOSONAR
                }) //NOSONAR
                .UseStartup<Startup>();

        public static void Shutdown()
        {
            cancelTokenSource.Cancel();
        }
    }
}
