using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Municipios = new HashSet<Municipios>();
        }

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Municipios> Municipios { get; set; }
    }
}
