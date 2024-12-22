using MediatR;

namespace BuildingBlocks.CQRS;

//Unit is representing Guid type in MediatR
//This will be an empty Interface, this provides a contract for all command types
public interface ICommand : ICommand<Unit>
{
    
}

/// <summary>
/// This will be specific for handling Command requests
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
    
}