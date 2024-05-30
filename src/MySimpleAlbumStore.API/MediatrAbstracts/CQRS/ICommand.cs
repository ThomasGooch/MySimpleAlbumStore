using MediatR;

namespace MySimpleAlbumStore.API.MediatrAbstracts.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : ICommand<Unit>
{
}
