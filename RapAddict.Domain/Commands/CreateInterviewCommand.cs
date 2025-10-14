using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateInterviewCommand : ICommandDefinition
    {
        public int Id { get; }
        public int JournalistId { get; }

        public CreateInterviewCommand(int id, int journalistId)
        {
            Id = id;
            JournalistId = journalistId;
        }
    }
}
