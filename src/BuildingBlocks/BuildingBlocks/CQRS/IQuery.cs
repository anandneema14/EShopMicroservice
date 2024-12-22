using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// This will be specific for handling Query requests
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    
}