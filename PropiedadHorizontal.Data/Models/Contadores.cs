using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Contadores
    {
        public Contadores()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
        }

        public string IdDocumentoContador { get; set; }
        public string CodigoTipoDocumentoContador { get; set; }
        public string NombreContador { get; set; }
        public string ApellidoContador { get; set; }
        public string CelularContador { get; set; }
        public string EmailContador { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
