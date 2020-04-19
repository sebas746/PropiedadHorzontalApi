namespace PropiedadHorizontal.Core.DTO
{
    public class ResidentesDto
    {
        public string IdDocumentoResidente { get; set; }
        public int IdTipoDocumentoResidente { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string NombresResidente { get; set; }
        public string ApellidosResidente { get; set; }
        public string CelularResidente { get; set; }
        public string EmailResidente { get; set; }
        public string GeneroResidente { get; set; }
        public TipoDocumentosDto TipoDocumento { get; set; }
    }
}
