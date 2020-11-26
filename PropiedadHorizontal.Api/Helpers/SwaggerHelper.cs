using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

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

                // Handle OIDC
                var securityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    { securityScheme, new string[] {} }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
