using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Videos
{
    public interface IClipRepository : 
        ICommandHandler<CreateClipCommand>,
        ICommandHandler<AddArtistToClipCommand>,
        IQueryHandler<GetClipsQuery, PagedList<Clip>>,
        IQueryHandler<GetClipQuery, ClipDetails>
    {
    }
}
