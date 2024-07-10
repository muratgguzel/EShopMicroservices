﻿
using BuildingBlocks.CQRS;
using Catalog.Api.Products.CreateProduct;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List <string> Category,string Description,string ImageFile,decimal Price): ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);


    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command object
            //save to database
            //return result

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };


            return new CreateProductResult(Guid.NewGuid());
        }

    }
}
