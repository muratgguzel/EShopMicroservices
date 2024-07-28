
namespace Catalog.Api.Products.GetProducts
{

    //public record GetProductsRequest();

    public record GetProductResponce(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        async void ICarterModule.AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {

                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductResponce>();

                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .Produces<GetProductResponce>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
           
        }
    }
}
