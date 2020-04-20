
namespace PropiedadHorizontal.Data.Models
{
    public partial class Copropiedades
    {
        public long IdCopropiedad { get; set; }
        public string NombreCopropiedad { get; set; }
        public decimal CoeficienteCopropiedad { get; set; }
        public decimal AreaCopropiedad { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoCopropiedad { get; set; }
        public string IdDocumentoResidente { get; set; }
        public decimal? CuotaAdministracionCopropiedad { get; set; }
        public string CodigoParqueaderoCopropiedad { get; set; }
        public bool? EsResidenteCopropietario { get; set; }

        public virtual Copropietarios Copropietario { get; set; }
        public virtual Residentes Residente { get; set; }
        public virtual TipoCopropiedades TipoCopropiedad { get; set; }
        public virtual PropiedadesHorizontales PropiedadHorizontal { get; set; }
    }
}
