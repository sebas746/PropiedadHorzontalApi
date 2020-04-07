using System.Collections.Generic;

namespace PropiedadHorizontal.Core.DTO
{
    public class PaginationResponse<T> where T : class
    {
        public PaginationResponse(int totalCount = 0)
        {
            TotalCount = totalCount;
            Content = new List<T>();
        }

        public int TotalCount { get; set; }

        public IEnumerable<T> Content { get; set; }
    }
}
