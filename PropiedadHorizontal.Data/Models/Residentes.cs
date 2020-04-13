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
        public string NombreResidente { get; set; }
        public string ApellidoResidente { get; set; }
        public string CelularResidente { get; set; }
        public string EmailResidente { get; set; }

        public virtual TipoDocumentos IdTipoDocumentoResidenteNavigation { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
