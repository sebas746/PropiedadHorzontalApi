﻿using System.Collections.Generic;

namespace PropiedadHorizontal.Core.DTO
{
    public class ResidentesDto
    {
        public string IdDocumentoResidente { get; set; }
        public string CodigoTipoDocumentoResidente { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string NombresResidente { get; set; }
        public string ApellidosResidente { get; set; }
        public string CelularResidente { get; set; }
        public string EmailResidente { get; set; }
        public string GeneroResidente { get; set; }
        public TipoDocumentosDto TipoDocumento { get; set; }
        public ICollection<CopropiedadesDto> Copropiedades { get; set; }
    }
}
