using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Persons
{
    public class PersonDetails: Person
    {
        [JsonPropertyOrder(10)]
        public string? FirstName { get; }

        [JsonPropertyOrder(11)]
        public string? LastName { get; }


        public PersonDetails(int id, string pseudo, DateTime addedDate, string? imageUrl) : base(id, pseudo, addedDate, imageUrl) 
        {
        }

        public PersonDetails(int id, string pseudo, DateTime addedDate, string? firstName, string? lastName, string? imageUrl) : base(id, pseudo, addedDate, imageUrl)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
