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
        public string CodigoTipoServicioProveedor { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public string CodigoTipoDocumentoProveedor { get; set; }
        public string NombreBancoProveedor { get; set; }
        public string CodigoTipoCuentaProveedor { get; set; }
        public string NumeroCuentaProveedor { get; set; }
        public string RutProveedor { get; set; }
        public string CodigoTipoPersonaTributaria { get; set; }

        public virtual PropiedadesHorizontales NitPropiedadHorizontalNavigation { get; set; }
    }
}
