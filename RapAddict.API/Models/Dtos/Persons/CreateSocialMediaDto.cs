using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Persons
{
    public class CreateSocialMediaDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; }

        public CreateSocialMediaDto(string name)
        {
            Name = name;
        }
    }
}
