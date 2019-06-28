using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Data;

namespace WebAPI
{
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup'
    public class Startup
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup'
    {
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Startup(IConfiguration)'
        public Startup(IConfiguration configuration)
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Startup(IConfiguration)'
        {
            Configuration = configuration;
        }

#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Configuration'
        public IConfiguration Configuration { get; }
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Configuration'

        // This method gets called by the runtime. Use this method to add services to the container.
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.ConfigureServices(IServiceCollection)'
        public void ConfigureServices(IServiceCollection services)
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.ConfigureServices(IServiceCollection)'
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>

                options.UseSqlite(Configuration.GetConnectionString("Sqlite"))
            
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Configure(IApplicationBuilder, IHostingEnvironment)'
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement 'Startup.Configure(IApplicationBuilder, IHostingEnvironment)'
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
