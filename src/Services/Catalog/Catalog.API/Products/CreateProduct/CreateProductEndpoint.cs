namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // In Minimal Api, if the request is of complex type, like the CreateProductRequest here, it will be acquired from the request body automatically

        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
            {

                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            })
            // These definitions are only to be used for clarification, not for functionality
            // Here, the router name is different from url, the former can be identified throughout the application
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("CreateProduct")
            .WithDescription("CreateProduct");
    }
}

