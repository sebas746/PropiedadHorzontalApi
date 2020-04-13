using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TiposCuentasBancarias
    {
        public TiposCuentasBancarias()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
            Proveedores = new HashSet<Proveedores>();
        }

        public int IdTipoCuentaBancaria { get; set; }
        public string NombreTipoCuentaBancaria { get; set; }
        public string DescripcionTipoCuentaBancaria { get; set; }

        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
