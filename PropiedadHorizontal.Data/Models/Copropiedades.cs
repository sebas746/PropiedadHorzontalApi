﻿
namespace PropiedadHorizontal.Data.Models
{
    public partial class Copropiedades
    {
        public long IdCopropiedad { get; set; }
        public string Nombre { get; set; }
        public decimal Indice { get; set; }
        public decimal Area { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoCopropiedad { get; set; }
        public string IdDocumentoArrendatario { get; set; }

        public virtual Arrendatarios Arrendatario { get; set; }
        public virtual Copropietarios Copropietario { get; set; }
        public virtual TipoCopropiedad TipoCopropiedad { get; set; }
        public virtual PropiedadesHorizontales PropiedadHorizontal { get; set; }
    }
}
