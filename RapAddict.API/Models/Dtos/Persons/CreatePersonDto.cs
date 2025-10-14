using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Persons
{
    public class CreatePersonDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Pseudo { get; }

        [StringLength(100, MinimumLength = 2)]
        public string? FirstName { get; }

        [StringLength(100, MinimumLength = 2)]
        public string? LastName { get; }

        public CreatePersonDto(string pseudo, string? firstName, string? lastName)
        {
            Pseudo = pseudo;
            FirstName = string.IsNullOrWhiteSpace(firstName) ? null : firstName;
            LastName = string.IsNullOrWhiteSpace(lastName) ? null : lastName;
        }
    }
}
