using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Models
{
    public partial class TipoCopropiedad
    {
        public TipoCopropiedad()
        {
            Copropiedades = new HashSet<Copropiedades>();
        }

        public int IdTipoCopropiedad { get; set; }
        public string NombreTipoCopropiedad { get; set; }
        public string DescripcionTipoCopropiedad { get; set; }

        public virtual ICollection<Copropiedades> Copropiedades { get; set; }
    }
}
