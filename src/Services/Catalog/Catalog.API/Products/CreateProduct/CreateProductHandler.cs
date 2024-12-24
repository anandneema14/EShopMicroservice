using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

//Below we are creating a Command Object and we will implement IRequest interface from MediatR nuget
//MediatR will prodice nesesary support to implement CQRS - Command Query Responsibility Segregation pattern
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<CreateProductResult>;

//Below is the Create Product Result object
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Implement business logic here
        //Create Product entity from the command object
        var product = new Product()
        {
            Name = command.Name,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        //Save to Db 
        //return result
        
        return Task.FromResult(new CreateProductResult(Guid.NewGuid()));
    }
}