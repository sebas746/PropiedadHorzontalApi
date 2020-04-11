
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
            CreateMap<Copropiedades, CopropiedadesDto>()
                .ForMember(co => co.NombrePropiedadHorizontal, map => map.MapFrom(m => m.PropiedadHorizontal.NombrePropiedadHorizontal))
                .ForMember(co => co.DescripcionTipoCopropiedad, map => map.MapFrom(m => m.TipoCopropiedad.DescripcionTipoCopropiedad))
                .ForMember(co => co.NombrePropietario, map => map.MapFrom(m => $"{m.Copropietario.Nombres} {m.Copropietario.Apellidos}" ));

            CreateMap<PropiedadesHorizontales, PropiedadHorizontalDto>();
            CreateMap<TipoDocumentos, TipoDocumentosDto>();
            CreateMap<TipoCopropiedades, TipoCopropiedadesDto>();
        }
    }
}

