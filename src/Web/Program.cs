using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {

                    // 取得當前執行環境
                    var env = hostingContext.HostingEnvironment;

                    // 加入 secretsettings
                    config.AddJsonFile("secretsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"secretsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    // 若從 CommandLine 執行環境時，帶入參數
                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
