using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TipoDocumentos
    {
        public TipoDocumentos()
        {
            Administradores = new HashSet<Administradores>();
            Contadores = new HashSet<Contadores>();
            Copropietarios = new HashSet<Copropietarios>();
            Ocupantes = new HashSet<Ocupantes>();
            Proveedores = new HashSet<Proveedores>();
        }

        public int IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }

        public virtual ICollection<Administradores> Administradores { get; set; }
        public virtual ICollection<Contadores> Contadores { get; set; }
        public virtual ICollection<Copropietarios> Copropietarios { get; set; }
        public virtual ICollection<Ocupantes> Ocupantes { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
