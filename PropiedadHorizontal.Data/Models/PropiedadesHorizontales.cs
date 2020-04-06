using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class PropiedadesHorizontales
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public decimal? IdMunicipio { get; set; }

        public virtual Municipios IdMunicipioNavigation { get; set; }
    }
}
