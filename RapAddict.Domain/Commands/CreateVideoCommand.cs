using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateVideoCommand: ICommandResultDefinition<int>
    {
        public string Title { get; }
        public DateTime? ReleaseDate { get; }
        public string Url { get; }
        public int? DurationMs { get; }

        public CreateVideoCommand(string title, DateTime? releaseDate, string url, int? durationMs)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Url = url;
            DurationMs = durationMs;
        }
    }
}
