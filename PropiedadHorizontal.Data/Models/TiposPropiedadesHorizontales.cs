using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TiposPropiedadesHorizontales
    {
        public TiposPropiedadesHorizontales()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
        }

        public int IdTipoPropiedadHorizontal { get; set; }
        public string NombreTipoPropiedadHorizontal { get; set; }
        public string DescripcionTipoPropiedadHorizontal { get; set; }

        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
