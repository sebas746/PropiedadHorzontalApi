
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;

namespace PropiedadHorizontal.Api.Mapping
{
    public class AutoMapping : AutoMapper.Profile
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapping()
        {
            CreateMap<Copropiedades, CopropiedadesDto>();
            CreateMap<CopropiedadesDto, Copropiedades>();
            CreateMap<PropiedadesHorizontales, PropiedadHorizontalDto>();
            CreateMap<PropiedadHorizontalDto, PropiedadesHorizontales>();
        }
    }
}

