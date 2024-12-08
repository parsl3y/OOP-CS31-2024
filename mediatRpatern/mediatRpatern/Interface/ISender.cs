namespace mediatRpatern.Interface;

public interface ISender
{
    TResponse Send<TRequest, TResponse>(TRequest request);
}