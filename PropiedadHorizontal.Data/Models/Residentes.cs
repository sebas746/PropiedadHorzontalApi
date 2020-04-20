using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Residentes
    {
        public Residentes()
        {
            Copropiedades = new HashSet<Copropiedades>();
        }

        public string IdDocumentoResidente { get; set; }
        public int IdTipoDocumentoResidente { get; set; }
        public string NombresResidente { get; set; }
        public string ApellidosResidente { get; set; }
        public string CelularResidente { get; set; }
        public string EmailResidente { get; set; }
        public string GeneroResidente { get; set; }

        public virtual TipoDocumentos TipoDocumento { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
