using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Videos
{
    public class AddArtistToInterviewCommand: ICommandDefinition
    {
        public int InterviewId { get; }
        public int ArtistId { get; }


        public AddArtistToInterviewCommand(int interviewId, int artistId)
        {
            InterviewId = interviewId;
            ArtistId = artistId;
        }
    }
}
