using CryptoCore.Crypto;
using CryptoCore.SecretConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region 加解密機制

            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));

            // !!! In a real implementation, you would have a factory here to get the password and salt securely <--- 
            // from somewhere such as Azure Key Vault, Environmental variable / another json setting (obfuscated in some way)
            // https://yanchi-huang.blogspot.com/2014/03/using-net-salting-your-password.html?m=0 about salt
            services.AddSingleton(x => new CryptoFactory().Create<AesManaged>(Configuration.GetSection("CryptoSettings:Key").Value, Configuration.GetSection("CryptoSettings:Salt").Value));
                                                                                              // ↑ bad example, because of password and salt get from file(ex. JSON, XML....)
            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IDecryptor, Decryptor>();
            services.AddSingleton<ISettingsValidator, SettingsValidator>();
            services.AddScoped<IDbSettingsResolved, DbSettingsBridge>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
