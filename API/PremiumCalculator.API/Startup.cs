using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using PremiumCalculator.API.Mapping;
using PremiumCalculator.API.Repository.Implementation;
using PremiumCalculator.API.Repository.Interface;
using PremiumCalculator.API.Services.Implementation;
using PremiumCalculator.API.Services.Interface;
using PremiumCalculator.DAL.Databases;

namespace PremiumCalculator.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddDbContext<TALContext>();
            TALContext.ConnectionString = Configuration.GetConnectionString("TALDatabase");
            services.AddScoped<TALContext>();

            services.AddCors(cx =>
            {
                cx.AddPolicy("premiumcalculatorapporigin", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                           .WithOrigins(Configuration["URL:AllowCorsURL"].Split(','));
                });

                cx.AddPolicy("AnyGET", builder =>
                {
                    builder.AllowAnyHeader()
                           .WithMethods("GET")
                           .AllowAnyOrigin();
                });
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<ICalculatorRepository, CalculatorRepository>();

            services.AddMemoryCache();

            ConfigureSwagger(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CalculatorMappingProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("premiumcalculatorapporigin");

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
               
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "PREMIUMCALCULATOR API");
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}");
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PremiumCalculator API",
                    Description = "PremiumCalculator API"
                });
                var app = PlatformServices.Default.Application;
                var swaggerFile = System.IO.Path.Combine(app.ApplicationBasePath, @"PremiumCalculator.API.xml");
                options.IncludeXmlComments(swaggerFile);
            });
        }
    }
}
