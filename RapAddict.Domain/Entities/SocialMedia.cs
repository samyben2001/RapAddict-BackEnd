namespace RapAddict.Domain.Entities
{
    public class SocialMedia
    {
        public int Id { get; }
        public string Name { get; }

        public SocialMedia(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
