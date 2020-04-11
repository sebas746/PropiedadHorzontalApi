﻿using Microsoft.Extensions.DependencyInjection;

namespace PropiedadHorizontal.Api.Helpers
{
    public static class CorsHelper
    {
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
