using RapAddict.Domain.Entities.Albums;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Albums
{
    public class GetAlbumQuery : IQueryDefinition<AlbumDetails>
    {
        public int Id { get; }

        public GetAlbumQuery(int id)
        {
            Id = id;
        }
    }
}
