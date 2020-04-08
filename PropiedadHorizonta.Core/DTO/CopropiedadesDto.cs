
using PropiedadHorizontal.Data.Models;

namespace PropiedadHorizontal.Core.DTO
{
    public class CopropiedadesDto
    {
        public decimal IdCopropiedad { get; set; }
        public string Nombre { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public decimal? Indice { get; set; }
        public decimal? Area { get; set; }
        public string IdDocumentoCopropietario { get; set; }
        public decimal? IdTipoCopropiedad { get; set; }
        public TipoCopropiedad TipoCopropiedad { get; set; }
        public PropiedadesHorizontales PropiedadesHorizontal { get; set; }

    }
}
