using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Proveedores
    {
        public string IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int IdTipoServicio { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public int? IdTipoDocumento { get; set; }

        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual TipoServicio IdTipoServicioNavigation { get; set; }
        public virtual PropiedadesHorizontales NitPropiedadHorizontalNavigation { get; set; }
    }
}
