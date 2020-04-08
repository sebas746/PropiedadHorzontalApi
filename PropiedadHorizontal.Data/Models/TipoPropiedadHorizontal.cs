using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TipoPropiedadHorizontal
    {
        public TipoPropiedadHorizontal()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
        }

        public int IdTipoPropiedadHorizontal { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
