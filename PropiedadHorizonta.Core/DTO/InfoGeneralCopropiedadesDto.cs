﻿namespace PropiedadHorizontal.Core.DTO
{
    public class InfoGeneralCopropiedadesDto
    {
        public decimal SumatoriaCoeficientes { get; set; }
        public decimal SumatoriaAreasPrivadas { get; set; }
        public int TotalCopropiedades { get; set; }
        public bool IsPropiedadHorizontalCompleted { get; set; }
        public string PropiedadHorizontaMessage { get; set; }
    }
}