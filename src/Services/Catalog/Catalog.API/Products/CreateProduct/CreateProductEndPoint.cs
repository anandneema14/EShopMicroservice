namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        try
        {
            app.MapPost("/products",
                    async (CreateProductRequest request, ISender sender) =>
                    {
                        //Adapt method is from Mapster package
                        //Mediator needs command object in order to trigger commandhandler
                        var command = request.Adapt<CreateProductCommand>();

                        var result = await sender.Send(command);

                        var response = result.Adapt<CreateProductResponse>();
                        return Results.Created($"/products/{response.Id}", response);
                    }).WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}