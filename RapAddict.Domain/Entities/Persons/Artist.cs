namespace RapAddict.Domain.Entities.Persons
{
    public class Artist : Person
    {
        public Artist(int id, string pseudo, string? firstName, string? lastName) : base(id, pseudo, firstName, lastName)
        {
        }
    }
}
