using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Users
{
    public class CreateUserCommand: ICommandResultDefinition<int>
    {
        public string Username { get; }
        public string Email { get; }
        public string Password { get; }
        public string? FirstName { get; }
        public string? LastName { get; }

        public CreateUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public CreateUserCommand(string username, string email, string password, string? firstName, string? lastName): this(username, email, password)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
