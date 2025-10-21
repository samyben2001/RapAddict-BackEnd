using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Albums
{
    public class CreateAlbumCommand : ICommandResultDefinition<int>
    {
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string? CoverUrl { get; }

        public CreateAlbumCommand(string title, DateTime? releaseDate, int? durationMs, string? coverUrl)
        {
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            CoverUrl = coverUrl;
        }
    }
}
