namespace RapAddict.Domain.Entities
{
    public class Journalist : Person
    {
        public Journalist(int id, string pseudo, string? firstName, string? lastName) : base(id, pseudo, firstName, lastName)
        {
        }
    }
}
