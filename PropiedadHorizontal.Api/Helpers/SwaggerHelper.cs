using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PropiedadHorizontal.Api.Helpers
{
    /// <summary>
    /// Swagger helper class.
    /// </summary>
    public class SwaggerHelper
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected SwaggerHelper() { }

        /// <summary>
        /// Static method to congfigure swagger.
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Propiedad Horizontal API", Version = "v1" });
            });
        }
    }
}
