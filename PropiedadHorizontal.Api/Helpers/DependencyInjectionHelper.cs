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

        public static void ConfigureDependencies(IServiceCollection services)
        {
            //Dependency Injection
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddScoped<IBaseContext, PropiedadHorizontalContext>();
            services.AddScoped<IPropiedadesHorizontalesRepository, PropiedadesHorizontalesRepository>();
            services.AddScoped<IPropiedadesHorizontalesService, PropiedadesHorizontalesService>();
        }
    }
}
