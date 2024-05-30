namespace MySimpleAlbumStore.API.MediatrAbstracts.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
