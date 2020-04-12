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

        public long IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamentos IdDepartamentoNavigation { get; set; }
        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
