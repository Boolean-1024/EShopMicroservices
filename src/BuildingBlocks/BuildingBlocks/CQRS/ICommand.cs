

using MediatR;

namespace BuildingBlocks.CQRS
{
    // A command without return value
    public interface ICommand : ICommand<Unit> { }
    public interface ICommand <out TResponse> : IRequest<TResponse> { }



}
