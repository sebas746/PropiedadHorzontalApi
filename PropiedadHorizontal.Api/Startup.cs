using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropiedadHorizontal.Api.Helpers;
using PropiedadHorizontal.Data.Context;
using AutoMapper;
using PropiedadHorizontal.Api.Mapping;
using System.Text.Json;

namespace PropiedadHorizontal.Api
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
            services.AddControllers();

            // Entity Framework Configuration
            services.AddDbContext<PropiedadHorizontalContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PropiedadHorizontal")));

            // Add framework services.
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    // set this option to TRUE to indent the JSON output
                    options.JsonSerializerOptions.WriteIndented = true;
                    // set this option to NULL to use PascalCase instead of
                    // camelCase (default)
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            SwaggerHelper.ConfigureService(services);
            CorsHelper.ConfigureService(services);
            DependencyInjectionHelper.ConfigureDependencies(services);


            services.AddAutoMapper(typeof(AutoMapping));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
                c.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
