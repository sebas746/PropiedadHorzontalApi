
namespace PropiedadHorizontal.Core.DTO
{
    public class CopropiedadesDto
    {
        public long IdCopropiedad { get; set; }
        public string NombreCopropiedad { get; set; }
        public string NitPropiedadHorizontal { get; set; }
        public string NombrePropiedadHorizontal { get; set; }
        public decimal CoeficienteCopropiedad { get; set; }
        public decimal AreaCopropiedad { get; set; }
        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoCopropiedad { get; set; }
        public string IdDocumentoResidente { get; set; }
        public decimal CuotaAdministracionCopropiedad { get; set; }
        public string DescripcionTipoCopropiedad { get; set; }
        public CopropietariosDto Copropietario { get; set; }
    }
}
