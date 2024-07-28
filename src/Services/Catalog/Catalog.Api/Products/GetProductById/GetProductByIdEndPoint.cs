﻿
namespace Catalog.Api.Products.GetProductById
{
    //public record GetProductByIdRequest();

    public record GetProductByIdResponce(Product Product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid Id, ISender sender) =>
            {

                var result = await sender.Send(new GetProductByIdQuery(Id));

                var response = result.Adapt<GetProductByIdResponce>();

                return Results.Ok(response);

            })
                .WithName("GetProductById")
                .Produces<GetProductByIdResponce>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product by Id");
            
                
        }
    }
}
