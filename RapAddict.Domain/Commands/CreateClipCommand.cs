using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateClipCommand: ICommandDefinition
    {
        public int Id { get; }
        public int ArtistId { get; }

        public CreateClipCommand(int id, int artistId)
        {
            Id = id;
            ArtistId = artistId;
        }
    }
}
