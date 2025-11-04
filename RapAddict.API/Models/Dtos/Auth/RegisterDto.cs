using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Auth
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; }

        [Required]
        [EmailAddress]
        [MaxLength(384)]
        public string Email { get; }
        
        [Required]
        public string Password { get; }
        
        public string? FirstName { get; }
        
        public string? LastName { get; }

        public RegisterDto(string username, string email, string password, string? firstName, string? lastName)   
        {
            Username = username;
            Email = email;
            Password = password;
            FirstName = string.IsNullOrWhiteSpace(firstName) ? null : firstName;
            LastName = string.IsNullOrWhiteSpace(lastName) ? null : lastName;
        }
    }
}
