using System.Collections.Generic;

namespace PropiedadHorizontal.Core.DTO
{
    public class CopropietariosDto
    {
        public string IdDocumentoCopropietario { get; set; }
        public int IdTipoDocumentoCopropietario { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string NombresCopropietario { get; set; }
        public string ApellidosCopropietario { get; set; }
        public string CelularCopropietario { get; set; }
        public string EmailCopropietario { get; set; }
        public string GeneroCopropietario { get; set; }
        public bool? EsResidenteCopropietario { get; set; }
        public TipoDocumentosDto TipoDocumento { get; set; }
        public ICollection<CopropiedadesDto> Copropiedades { get; set; }
    }
}
