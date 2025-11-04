using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class PagedListDto
    {
        [Range(1, int.MaxValue, ErrorMessage ="Le numéro de la page est de minimum 1")]
        public int PageNumber { get; set; } = 1;

        [Range(1, 50, ErrorMessage = "La taille de la page doit être comprise entre 1 et 50!")]
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
