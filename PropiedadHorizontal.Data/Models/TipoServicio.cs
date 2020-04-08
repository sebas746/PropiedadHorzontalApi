using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TipoServicio
    {
        public TipoServicio()
        {
            Proveedores = new HashSet<Proveedores>();
        }

        public int IdTipoServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
