namespace RapAddict.Domain.Entities.Persons
{
    public class Person
    {
        public int Id { get; }
        public string Pseudo { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? ImageUrl { get; }


        public Person(int id, string pseudo, string? imageUrl)
        {
            Id = id;
            Pseudo = pseudo;
            ImageUrl = imageUrl;
        }

        public Person(int id, string pseudo, string? firstName, string? lastName, string? imageUrl)
        {
            Id = id;
            Pseudo = pseudo;
            FirstName = firstName;
            LastName = lastName;
            ImageUrl = imageUrl;
        }
    }
}
