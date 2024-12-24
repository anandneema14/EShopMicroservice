//Carter is a library that provides a more structured way to organize our EndPoints and simplifies the creation of HTTP request pipelines
using Carter;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndPoint : ICarterModule 
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }
}