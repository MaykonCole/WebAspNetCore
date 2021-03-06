﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using ProjetoWeb.Data;
using ProjetoWeb.Services;
using System.Globalization;


namespace ProjetoWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ProjetoWebContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("ProjetoWebContext"), builder =>
                    builder.MigrationsAssembly("ProjetoWeb")));

            // Registra o nosso Serviço no sistema de Injeção de Dependências da Aplicação
            services.AddScoped<SeedingService>();
            services.AddScoped<VendedorService>();
            services.AddScoped<DepartamentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingservice)
        {
            // Definindo localização padrão do projeto
            var enUS = new CultureInfo("en-US");
            var localizacaoPadrao = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUS),
                SupportedCultures = new List<CultureInfo> { enUS },
                SupportedUICultures = new List<CultureInfo> { enUS }
            };



            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Popular a base de dados
                seedingservice.Enviar(); 
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
