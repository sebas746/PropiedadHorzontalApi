using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Core.DTO
{
    public class PaginationResponse<T> where T : class
    {
        public PaginationResponse(PaginationDto pagination, int totalCount = 0)
        {
            TotalCount = totalCount;
            Content = new List<T>();
            PageIndex = pagination.PageNumber;
            PageSize = pagination.PageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);
            SortColumn = pagination.OrderBy;
            SortOrder = pagination.SortOrder;
            Filter = pagination.Filter;
        }

        #region Properties
        public IEnumerable<T> Content { get; set; }

        /// <summary>
        /// Zero-based index of current page.
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Total pages count
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// TRUE if the current page has a previous page, 
        /// FALSE otherwise.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        /// <summary>
        /// Sorting Column name (or null if none set)
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Sorting Order ("ASC", "DESC" or null if none set)
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Filter Column name (or null if none set)
        /// </summary>
        public string Filter { get; set; }
        #endregion
    }
}
