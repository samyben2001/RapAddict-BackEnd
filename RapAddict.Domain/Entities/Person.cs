namespace RapAddict.Domain.Entities
{
    public class Person
    {
        public int Id { get; }
        public string Pseudo { get; }
        public string? FirstName { get; }
        public string? LastName { get; }

        public Person(int id, string pseudo, string? firstName, string? lastName)
        {
            Id = id;
            Pseudo = pseudo;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
