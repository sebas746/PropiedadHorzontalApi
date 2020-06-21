using Microsoft.Extensions.DependencyInjection;

namespace PropiedadHorizontal.Api.Helpers
{
    /// <summary>
    /// Class for cors helper configuration.
    /// </summary>
    public static class CorsHelper
    {
        /// <summary>
        /// Static method for configure cors.
        /// </summary>
        /// <param name="service">Service collection from Services.cs</param>
        public static void ConfigureService(IServiceCollection service)
        {
            service.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
    }
}
