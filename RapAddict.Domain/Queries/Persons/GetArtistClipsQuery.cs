using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistClipsQuery : PagedListQuery, IQueryDefinition<PagedList<Clip>>
    {
        public int Id { get; }

        public GetArtistClipsQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
