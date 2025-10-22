namespace RapAddict.Domain.Entities.Persons
{
    public class ContentCreator : Person
    {
        public ContentCreator(int id, string pseudo, DateTime addedDate, string? imageUrl) : base(id, pseudo, addedDate, imageUrl)
        {
        }
    }
}
