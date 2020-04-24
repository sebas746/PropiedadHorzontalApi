using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Context;

namespace PropiedadHorizontal.Api.Helpers
{
    public class IdentityHelper
    {
        public static void ConfigureDependencies(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PropiedadHorizontal")));

            services.AddIdentity<AppUser, IdentityRole>()
              .AddEntityFrameworkStores<AppIdentityDbContext>()
              .AddDefaultTokenProviders();

            services.AddIdentityServer().AddDeveloperSigningCredential()
               // this adds the operational data from DB (codes, tokens, consents)
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("PropiedadHorizontal"));
          // this enables automatic token cleanup. this is optional.
          options.EnableTokenCleanup = true;
                   options.TokenCleanupInterval = 30; // interval in seconds
      })
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryApiResources(Config.GetApiResources())
               .AddInMemoryClients(Config.GetClients())
               .AddAspNetIdentity<AppUser>();
        }
    }
}
