namespace RapAddict.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; }
        public string Email { get; }
        public string Password { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        internal User(int id, string username, string email, string password, string? firstName, string? lastName)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
