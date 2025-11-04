using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Videos
{
    public interface IAnalyseRepository : 
        ICommandHandler<CreateAnalyseCommand>,
        ICommandHandler<AddArtistToAnalyseCommand>,
        IQueryHandler<GetAnalysesQuery, PagedList<Analyse>>,
        IQueryHandler<GetAnalyseQuery, AnalyseDetails>
    {
    }
}
