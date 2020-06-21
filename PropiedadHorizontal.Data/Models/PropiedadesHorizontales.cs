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
        public string CodigoTipoPropiedadHorizontal { get; set; }
        public string IdDocumentoAdministrador { get; set; }
        public string IdDocumentoContador { get; set; }
        public decimal? AreaTotalLotePropiedadHorizontal { get; set; }
        public decimal? AreaPrivadaConstruidaPropiedadHorizontal { get; set; }
        public decimal? AreaTotalCesionPropiedadHorizontal { get; set; }
        public bool? IsActive { get; set; }
        public string NombreBancoPropiedadHorizontal { get; set; }
        public string CodigoTipoCuentaPropiedadHorizontal { get; set; }
        public string NumeroCuentaPropiedadHorizontal { get; set; }

        public virtual Administradores Administrador { get; set; }
        public virtual Contadores Contador { get; set; }
        public virtual Municipios Municipio { get; set; }
        public virtual ICollection<AreasComunes> AreasComunes { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
