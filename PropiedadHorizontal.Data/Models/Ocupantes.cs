using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Ocupantes
    {
        public Ocupantes()
        {
            Copropiedades = new HashSet<Copropiedades>();
        }

        public string IdDocumentoOcupante { get; set; }
        public int IdTipoDocumentoOcupante { get; set; }
        public string NombreOcupante { get; set; }
        public string ApellidoOcupante { get; set; }
        public string CelularOcupante { get; set; }
        public string EmailOcupante { get; set; }

        public virtual TipoDocumentos IdTipoDocumentoOcupanteNavigation { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
