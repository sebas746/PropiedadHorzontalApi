using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Municipios
    {
        public Municipios()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
        }

        public decimal IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public decimal? IdDepartamento { get; set; }

        public virtual Departamentos IdDepartamentoNavigation { get; set; }
        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
