
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Utils;

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
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(co => co.IdCopropiedad, map => map.MapFrom(m => m.IdCopropiedad))
                .ForMember(co => co.Copropietario, map => map.MapFrom(m => m.Copropietario))
                .ForMember(co => co.Residente, map => map.MapFrom(m => m.Residente))
                .ForMember(co => co.IdDocumentoCopropietario, map => map.MapFrom(m => m.IdDocumentoCopropietario))
                .ForMember(co => co.NitPropiedadHorizontal, map => map.MapFrom(m => m.NitPropiedadHorizontal))
                .ForMember(co => co.CoeficienteCopropiedad, map => map.MapFrom(m => m.CoeficienteCopropiedad))
                .ForMember(co => co.AreaCopropiedad, map => map.MapFrom(m => m.AreaCopropiedad))
                .ForMember(co => co.IdDocumentoCopropietario, map => map.MapFrom(m => m.IdDocumentoCopropietario))
                .ForMember(co => co.IdDocumentoResidente, map => map.MapFrom(m => m.IdDocumentoResidente));
            CreateMap<CopropiedadesDto, Copropiedades>()
                .ForMember(co => co.Copropietario, map => map.MapFrom(m => m.Copropietario))
                .ForMember(co => co.Residente, map => map.MapFrom(m => m.Residente))
                .ForMember(co => co.PropiedadHorizontal, map => map.Ignore());

            CreateMap<PropiedadesHorizontales, PropiedadHorizontalDto>();
            CreateMap<ItemsComunes, ItemsComunesDto>();
            CreateMap<Residentes, ResidentesDto>();
            CreateMap<ResidentesDto, Residentes>();

            CreateMap<Copropietarios, CopropietariosDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                
            CreateMap<CopropietariosDto, Copropietarios>();
            CreateMap<PaginationDto, Pagination>();
        }
    }
}

