namespace RapAddict.Domain.Entities
{
    public class EntityPlatform
    {
        public string Name { get; }
        public string IdFromPlatform { get; }

        public EntityPlatform(string name, string idFromPlatform)
        {
            Name = name;
            IdFromPlatform = idFromPlatform;
        }
    }
}
