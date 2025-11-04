using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Auth
{
    public class LoginDto
    {
        [Required]
        public string Login { get; }
        [Required]
        public string Password { get; }

        public LoginDto(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
