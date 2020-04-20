﻿
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
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(co => co.IdCopropiedad, map => map.MapFrom(m => m.IdCopropiedad))
                .ForMember(co => co.Copropietario, map => map.MapFrom(m => m.Copropietario))
                .ForMember(co => co.Residente, map => map.MapFrom(m => m.Residente))
                .ForMember(co => co.IdDocumentoCopropietario, map => map.MapFrom(m => m.IdDocumentoCopropietario))
                .ForMember(co => co.NitPropiedadHorizontal, map => map.MapFrom(m => m.NitPropiedadHorizontal))
                .ForMember(co => co.CoeficienteCopropiedad, map => map.MapFrom(m => m.CoeficienteCopropiedad))
                .ForMember(co => co.AreaCopropiedad, map => map.MapFrom(m => m.AreaCopropiedad))
                .ForMember(co => co.IdDocumentoCopropietario, map => map.MapFrom(m => m.IdDocumentoCopropietario))
                .ForMember(co => co.IdTipoCopropiedad, map => map.MapFrom(m => m.IdTipoCopropiedad))
                .ForMember(co => co.IdDocumentoResidente, map => map.MapFrom(m => m.IdDocumentoResidente))
                .ForMember(co => co.DescripcionTipoCopropiedad, map => map.MapFrom(m => m.TipoCopropiedad.DescripcionTipoCopropiedad));
            CreateMap<CopropiedadesDto, Copropiedades>()
                .ForMember(co => co.Copropietario, map => map.MapFrom(m => m.Copropietario))
                .ForMember(co => co.Residente, map => map.MapFrom(m => m.Residente))
                .ForMember(co => co.TipoCopropiedad, map => map.Ignore())
                .ForMember(co => co.PropiedadHorizontal, map => map.Ignore());

            CreateMap<PropiedadesHorizontales, PropiedadHorizontalDto>();

            CreateMap<Residentes, ResidentesDto>();
            CreateMap<ResidentesDto, Residentes>();

            CreateMap<TipoDocumentos, TipoDocumentosDto>();
            
            CreateMap<TipoCopropiedades, TipoCopropiedadesDto>();

            CreateMap<Copropietarios, CopropietariosDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
                .ForMember(co => co.DescripcionTipoDocumento, map => map.MapFrom(m => m.TipoDocumento.DescripcionTipoDocumento))
                .ForMember(co => co.TipoDocumento, map => map.Ignore());
            CreateMap<CopropietariosDto, Copropietarios>();

        }
    }
}

