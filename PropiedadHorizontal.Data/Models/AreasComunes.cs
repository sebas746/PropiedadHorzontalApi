using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class AreasComunes
    {
        public int IdAreaComun { get; set; }
        public string NombreAreaComun { get; set; }
        public string NitPropiedadHorizontal { get; set; }

        public virtual PropiedadesHorizontales NitPropiedadHorizontalNavigation { get; set; }
    }
}
