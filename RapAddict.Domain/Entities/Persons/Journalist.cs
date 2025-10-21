namespace RapAddict.Domain.Entities.Persons
{
    public class Journalist : Person
    {
        public Journalist(int id, string pseudo, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, firstName, lastName, imageUrl)
        {
        }
    }
}
