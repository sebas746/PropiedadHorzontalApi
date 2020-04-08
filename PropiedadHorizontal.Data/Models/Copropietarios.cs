using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Copropietarios
    {
        public Copropietarios()
        {
            Copropiedades = new HashSet<Copropiedades>();
        }

        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
