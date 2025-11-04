using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Persons;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Persons
{
    public interface IContentCreatorRepository: 
        ICommandHandler<CreateContentCreatorCommand>,
        ICommandHandler<AddStreamingPlatformToContentCreatorCommand>,
        IQueryHandler<GetContentCreatorsQuery, PagedList<ContentCreator>>,
        IQueryHandler<GetContentCreatorQuery, ContentCreatorDetails>
    {
    }
}
