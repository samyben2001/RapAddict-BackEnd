using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos
{
    public class CreateStreamingPlatformDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; }

        public CreateStreamingPlatformDto(string name)
        {
            Name = name;
        }
    }
}
