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
        public int IdTipoDocumentoCopropietario { get; set; }
        public string NombreCopropietario { get; set; }
        public string ApellidoCopropietario { get; set; }
        public string CelularCopropietario { get; set; }
        public string EmailCopropietario { get; set; }
        public bool? EsOcupante { get; set; }

        public virtual TipoDocumentos TipoDocumento { get; set; }
        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
