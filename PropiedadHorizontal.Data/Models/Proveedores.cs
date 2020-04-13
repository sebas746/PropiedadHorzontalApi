using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class Proveedores
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }
        public int IdTipoServicioProveedor { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public int? IdTipoDocumentoProveedor { get; set; }
        public string NombreBancoProveedor { get; set; }
        public int? IdTipoCuentaProveedor { get; set; }
        public string NumeroCuentaProveedor { get; set; }

        public virtual TiposCuentasBancarias IdTipoCuentaProveedorNavigation { get; set; }
        public virtual TipoDocumentos IdTipoDocumentoProveedorNavigation { get; set; }
        public virtual TipoServicio IdTipoServicioProveedorNavigation { get; set; }
        public virtual PropiedadesHorizontales NitPropiedadHorizontalNavigation { get; set; }
    }
}
