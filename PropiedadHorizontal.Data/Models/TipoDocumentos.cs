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
            Proveedores = new HashSet<Proveedores>();
            Residentes = new HashSet<Residentes>();
        }

        public int IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }

        public virtual ICollection<Administradores> Administradores { get; set; }
        public virtual ICollection<Contadores> Contadores { get; set; }
        public virtual ICollection<Copropietarios> Copropietarios { get; set; }
        public virtual ICollection<Proveedores> Proveedores { get; set; }
        public virtual ICollection<Residentes> Residentes { get; set; }
    }
}
