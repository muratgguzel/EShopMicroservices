using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryRequest();

    public record GetProductByCategoryResponse(IEnumerable<Product> Prodcuts);
    public class GetProductByCategoryEndPoint :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}" , async (string category,ISender sender)=>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);

            }                                        
                )
                .WithName("GetProductByCategory")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get prodcut by category")
                .WithDescription("Get prodcut by category");

        }
    }
}
