namespace RapAddict.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; }
        public string Email { get; }
        public DateTime InscriptionDate { get; }


        public User(int id, string username, string email, DateTime inscriptionDate)
        {
            Id = id;
            Username = username;
            Email = email;
            InscriptionDate = inscriptionDate;
        }
    }
}
