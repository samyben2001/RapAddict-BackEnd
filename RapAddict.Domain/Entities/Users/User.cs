namespace RapAddict.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; }
        public string Email { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public User(int id, string username, string email, string? firstName, string? lastName)
        {
            Id = id;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
