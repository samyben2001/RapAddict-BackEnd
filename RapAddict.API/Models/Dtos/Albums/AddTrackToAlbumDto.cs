namespace RapAddict.API.Models.Dtos.Albums
{
    public class AddTrackToAlbumDto
    {
        public int TrackId { get; }
        public int Position { get; }

        public AddTrackToAlbumDto(int trackId, int position)
        {
            TrackId = trackId;
            Position = position;
        }
    }
}
