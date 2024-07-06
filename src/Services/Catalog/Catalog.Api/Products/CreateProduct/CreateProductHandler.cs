namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List <string> Category,string Description,string ImageFile,decimal Price);


    public class CreateProductHandler
    {
    }
}
