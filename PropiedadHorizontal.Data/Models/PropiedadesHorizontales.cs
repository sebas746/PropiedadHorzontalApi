using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class PropiedadesHorizontales
    {
        public PropiedadesHorizontales()
        {
            AreasComunes = new HashSet<AreasComunes>();
            Copropiedades = new HashSet<Copropiedades>();
            Proveedores = new HashSet<Proveedores>();
        }

        public string NitPropiedadHorizontal { get; set; }
        public string NombrePropiedadHorizontal { get; set; }
        public string DireccionPropiedadHorizontal { get; set; }
        public string TelefonoPropiedadHorizontal { get; set; }
        public string EmailPropiedadHorizontal { get; set; }
        public string LogoPropiedadHorizontal { get; set; }
        public long? IdMunicipio { get; set; }
        public int? IdTipoPropiedadHorizontal { get; set; }
        public string IdDocumentoAdministrador { get; set; }
        public string IdDocumentoContador { get; set; }
        public decimal? AreaTotalLotePropiedadHorizontal { get; set; }
        public decimal? AreaPrivadaConstruidaPropiedadHorizontal { get; set; }
        public decimal? AreaTotalCesionPropiedadHorizontal { get; set; }
        public bool? IsActive { get; set; }

        public virtual Administradores IdDocumentoAdministradorNavigation { get; set; }
        public virtual Contadores IdDocumentoContadorNavigation { get; set; }
        public virtual Municipios Municipio { get; set; }
        public virtual TiposPropiedadesHorizontales TipoPropiedadHorizontal { get; set; }
        public virtual ICollection<AreasComunes> AreasComunes { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
