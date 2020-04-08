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
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public long? IdMunicipio { get; set; }
        public int? IdTipoPropiedadHorizontal { get; set; }
        public string IdDocumentoAdministrador { get; set; }

        public virtual Administradores Administrador { get; set; }
        public virtual Municipios Municipio { get; set; }
        public virtual TipoPropiedadHorizontal TipoPropiedadHorizontal { get; set; }
        public virtual ICollection<AreasComunes> AreasComunes { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
