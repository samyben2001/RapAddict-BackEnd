using System.Text.Json.Serialization;

namespace RapAddict.Domain.Entities.Persons
{
    public class Artist : Person
    {
        public Artist(int id,string pseudo, DateTime addedDate,string? imageUrl) : base(id, pseudo, addedDate, imageUrl)
        {
            
        }
    }
}
