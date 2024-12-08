namespace mediatRpatern.Interface;

public interface IRequestHandler<TRequest, TResponse>
{
    TResponse Handle(TRequest request);
}