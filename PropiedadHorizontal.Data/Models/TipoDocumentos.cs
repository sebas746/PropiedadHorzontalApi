using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TipoDocumentos
    {
        public TipoDocumentos()
        {
            Administradores = new HashSet<Administradores>();
            Arrendatarios = new HashSet<Arrendatarios>();
            Copropietarios = new HashSet<Copropietarios>();
            Proveedores = new HashSet<Proveedores>();
        }

        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }

        public virtual ICollection<Administradores> Administradores { get; set; }
        public virtual ICollection<Arrendatarios> Arrendatarios { get; set; }
        public virtual ICollection<Copropietarios> Copropietarios { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
