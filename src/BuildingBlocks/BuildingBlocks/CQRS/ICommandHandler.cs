

using MediatR;

namespace BuildingBlocks.CQRS
{



    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>{}


    // Here, the keyword "in" means that this method can accept a more general type of TCommand
    public interface ICommandHandler<in TCommand, TResponse> :IRequestHandler<TCommand, TResponse> 
        where TCommand : ICommand<TResponse>
        where TResponse : notnull{}




}
