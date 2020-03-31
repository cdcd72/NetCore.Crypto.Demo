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
                .ConfigureAppConfiguration((hostingContext, config) => 
                {
                    // 清除預設資料提供來源
                    config.Sources.Clear();

                    // 取得當前執行環境
                    var env = hostingContext.HostingEnvironment;

                    // 加入 appsettings
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    // 加入 secretsettings
                    config.AddJsonFile("secretsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"secretsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    // 加入環境變數
                    config.AddEnvironmentVariables();

                    // 若從 CommandLine 執行環境時，帶入參數
                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
