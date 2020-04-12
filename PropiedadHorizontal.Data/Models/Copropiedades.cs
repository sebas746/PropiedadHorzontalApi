
namespace PropiedadHorizontal.Data.Models
{
    public partial class Copropiedades
    {
        public long IdCopropiedad { get; set; }
        public string NombreCopropiedad { get; set; }
        public decimal IndiceCopropiedad { get; set; }
        public decimal AreaCopropiedad { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoCopropiedad { get; set; }
        public string IdDocumentoOcupante { get; set; }

        public virtual Copropietarios Copropietario { get; set; }
        public virtual Ocupantes Ocupante { get; set; }
        public virtual TipoCopropiedades TipoCopropiedad { get; set; }
        public virtual PropiedadesHorizontales PropiedadHorizontal { get; set; }
    }
}
