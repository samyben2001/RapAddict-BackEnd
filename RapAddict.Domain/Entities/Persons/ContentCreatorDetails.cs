namespace RapAddict.Domain.Entities.Persons
{
    public class ContentCreatorDetails : PersonDetails
    {
        public ContentCreatorDetails(int id, string pseudo, DateTime addedDate, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, addedDate, firstName, lastName, imageUrl)
        {
        }
    }
}
