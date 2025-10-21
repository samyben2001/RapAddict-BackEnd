namespace RapAddict.API.Models.Dtos.Albums
{
    public class GetAlbumDto
    {
        public int Id { get; }

        public GetAlbumDto() { }

        public GetAlbumDto(int id)
        {
            Id = id;
        }
    }
}
