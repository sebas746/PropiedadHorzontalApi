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
        public string CodigoTipoDocumentoCopropietario { get; set; }
        public string NombresCopropietario { get; set; }
        public string ApellidosCopropietario { get; set; }
        public string CelularCopropietario { get; set; }
        public string EmailCopropietario { get; set; }
        public string GeneroCopropietario { get; set; }
        public DateTime? FechaNacimientoCopropietario { get; set; }

        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
