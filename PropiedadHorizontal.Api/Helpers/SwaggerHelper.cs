using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace PropiedadHorizontal.Api.Helpers
{
    public class SwaggerHelper
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Propiedad Horizontal API", Version = "v1" });
            });
        }
    }
}
