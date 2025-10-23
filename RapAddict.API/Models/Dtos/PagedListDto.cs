namespace RapAddict.API.Models.Dtos
{
    public class PagedListDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public PagedListDto()
        {
        }

        public PagedListDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
