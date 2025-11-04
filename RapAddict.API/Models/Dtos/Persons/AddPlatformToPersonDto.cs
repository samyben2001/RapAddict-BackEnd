using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Persons
{
    public class AddPlatformToPersonDto
    {
        [Required]
        public int PlatformId { get; }
        [Required]
        public string PersonPlatformId { get; }


        public AddPlatformToPersonDto(int platformId, string personPlatformId)
        {
            PlatformId = platformId;
            PersonPlatformId = personPlatformId;
        }
    }
}
