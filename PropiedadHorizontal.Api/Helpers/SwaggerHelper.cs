using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PropiedadHorizontal.Api.Helpers
{
    public class SwaggerHelper
    {
        protected SwaggerHelper() { }
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Propiedad Horizontal API", Version = "v1" });
            });
        }
    }
}
