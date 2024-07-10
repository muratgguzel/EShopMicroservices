using BuildingBlocks.CQRS;
namespace Catalog.Api.Products.CreateProduct
{

    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    //Mapster maps the request body to command object
                    var command = request.Adapt<CreateProductCommand>();

                    //This triggers the mediatr handler
                    var result = await sender.Send(command);

                    //Adapt the result
                    var response = result.Adapt<CreateProductResponse>();

                    //Return back to the responce
                    return Results.Created($"/products/{response.Id}", response);


                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");

           
        }
    }
}
