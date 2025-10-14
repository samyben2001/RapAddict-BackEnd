namespace RapAddict.Domain.Entities.Albums
{
    public class StreamingPlatform
    {
        public int Id { get; }
        public string Name { get; }

        public StreamingPlatform(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
