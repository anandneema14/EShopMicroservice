using MediatR;

namespace Catalog.API.Products.CreateProduct;

//Below we are creating a Command Object and we will implement IRequest interface from MediatR nuget
//MediatR will prodice nesesary support to implement CQRS - Command Query Responsibility Segregation pattern
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : IRequest<CreateProductResult>;

//Below is the Create Product Result object
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //Implement business logic here
        throw new NotImplementedException();
    }
}