
using eventmanager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eventmanager.Startup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configura i servizi di cui hai bisogno
            services.Configure<SecuritySettings>(Configuration.GetSection("SecuritySettings"));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configura l'applicazione e il pipeline di richiesta
        }
    }
}



