using System.ComponentModel.DataAnnotations;

namespace RapAddict.Domain.Queries
{
    public class PagedListQuery
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public PagedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
