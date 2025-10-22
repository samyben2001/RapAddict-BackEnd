namespace RapAddict.Domain.Entities.Persons
{
    public class Person
    {
        public int Id { get; }
        public string Pseudo { get; }
        public DateTime AddedDate { get; }
        public string? ImageUrl { get; }

        public Person(int id, string pseudo, DateTime addedDate, string? imageUrl)
        {
            Id = id;
            Pseudo = pseudo;
            AddedDate = addedDate;
            ImageUrl = imageUrl;
        }
    }
}
