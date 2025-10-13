using Tools.Cqs.Results;

namespace Tools.Cqs.Commands
{
    public interface ICommandResultHandler<TCommand, TResult>
        where TCommand : ICommandResultDefinition<TResult>
    {
        ICqsResult<TResult> Execute(TCommand command);
    }
}
