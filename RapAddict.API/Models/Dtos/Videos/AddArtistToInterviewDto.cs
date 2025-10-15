using System.ComponentModel.DataAnnotations;

namespace RapAddict.API.Models.Dtos.Videos
{
    public class AddArtistToInterviewDto
    {
        [Required]
        public int InterviewId { get; }

        [Required]
        public int ArtistId { get; }


        public AddArtistToInterviewDto(int interviewId, int artistId)
        {
            InterviewId = interviewId;
            ArtistId = artistId;
        }
    }
}
