
namespace RapAddict.Domain.Entities.Users
{
    public class UserDetails : User
    {
        public string? FirstName { get; }
        public string? LastName { get; }


        public UserDetails(int id, string username, string email, DateTime inscriptionDate, string? firstName, string? lastName) : base(id, username, email, inscriptionDate)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
