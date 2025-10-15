using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Videos
{
    public class AddArtistToAnalyseCommand: ICommandDefinition
    {
        public int AnalyseId { get; }
        public int ArtistId { get; }


        public AddArtistToAnalyseCommand(int analyseId, int artistId)
        {
            AnalyseId = analyseId;
            ArtistId = artistId;
        }
    }
}
