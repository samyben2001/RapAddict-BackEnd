using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Persons;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Persons
{
    public interface IJournalistRepository : 
        ICommandHandler<CreateJournalistCommand>,
        ICommandHandler<AddStreamingPlatformToJournalistCommand>,
        IQueryHandler<GetJournalistsQuery, PagedList<Journalist>>,
        IQueryHandler<GetJournalistQuery, JournalistDetails>
    {
    }
}
