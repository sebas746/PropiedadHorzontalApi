using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Administradores
    {
        public Administradores()
        {
            PropiedadesHorizontales = new HashSet<PropiedadesHorizontales>();
        }

        public string IdDocumentoAdministrador { get; set; }
        public string CodigoTipoDocumentoAdministrador { get; set; }
        public string NombreAdministrador { get; set; }
        public string ApellidoAdministrador { get; set; }
        public string CelularAdministrador { get; set; }
        public string EmailAdministrador { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
