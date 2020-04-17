
namespace PropiedadHorizontal.Core.DTO
{
    public class PaginationDto
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        public int Skip { get; set; }

        public string OrderBy { get; set; }

        public string SortOrder { get; set; }

        public string Filter { get; set; }
    }
}
