using Microsoft.Extensions.DependencyInjection;
using PropiedadHorizontal.Business.Services;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Repositories;
using PropiedadHorizontal.Data.Repositories.Interfaces;

namespace PropiedadHorizontal.Api.Helpers
{
    public class DependencyInjectionHelper
    {
        protected DependencyInjectionHelper() { }

        /// <summary>
        /// Method to configure dependency injection.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDependencies(IServiceCollection services)
        {
            //Dependency Injection
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddScoped<IBaseContext, PropiedadHorizontalContext>();
            services.AddScoped<IPropiedadesHorizontalesRepository, PropiedadesHorizontalesRepository>();
            services.AddScoped<IPropiedadesHorizontalesService, PropiedadesHorizontalesService>();
            services.AddScoped<ICopropiedadesRepository, CopropiedadesRepository>();
            services.AddScoped<ICopropiedadesService, CopropiedadesService>();
            services.AddScoped<ITipoDocumentosRepository, TipoDocumentosRepository>();
            services.AddScoped<ITipoDocumentosService, TipoDocumentosService>();
            services.AddScoped<ITipoCopropiedadesRepository, TipoCopropiedadesRepository>();
            services.AddScoped<ITipoCopropiedadesService, TipoCopropiedadesService>();
            services.AddScoped<ICopropietariosRepository, CopropietariosRepository>();
            services.AddScoped<ICopropietariosService, CopropietariosService>();
            services.AddScoped<IResidentesRepository, ResidentesRepository>();
        }
    }
}
