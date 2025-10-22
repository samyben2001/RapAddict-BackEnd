namespace RapAddict.Domain.Entities.Persons
{
    public class Journalist : Person
    {
        public Journalist(int id, string pseudo, DateTime addedDate, string? imageUrl) : base(id, pseudo, addedDate, imageUrl)
        {
        }
    }
}
