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

        public string IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
    }
}
