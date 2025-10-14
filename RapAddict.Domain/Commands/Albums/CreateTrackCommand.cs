using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Albums
{
    public class CreateTrackCommand : ICommandResultDefinition<int>
    {
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public int? DurationMs { get; }
        public string? Lyrics { get; }

        public CreateTrackCommand(string title, DateTime? releaseDate, int? durationMs, string? lyrics)
        {
            Title = title;
            ReleaseDate = releaseDate;
            DurationMs = durationMs;
            Lyrics = lyrics;
        }
    }
}
