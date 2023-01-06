using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApi.Application.Commands.Product.Delete;
using TestApi.Application.Commands.Product.New;
using TestApi.Application.Commands.Product.Update;
using TestApi.Application.Queries.Product;

namespace TestApi.Presentation.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator Mediator;
    public ProductsController(IMediator mediator) => Mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetProducts() => Ok(await Mediator.Send(new GetProductsQuery()));

    [HttpGet]
    public async Task<IActionResult> GetProductsInCategory(int categoryId) =>
        Ok(await Mediator.Send(new GetProductsFromCategoryQuery { CategoryId = categoryId }));

    [HttpGet]
    public async Task<IActionResult> GetProduct(int id) => Ok(await Mediator.Send(new GetProductQuery { Id = id }));

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> AddProduct(AddNewProductCommand model) => Created("", await Mediator.Send(model));

    [HttpPut]
    //[Authorize]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand model) => Ok(await Mediator.Send(model));

    [HttpDelete]
    //[Authorize]
    public async Task<IActionResult> DeleteProduct(DeleteProductCommand model) => Ok(await Mediator.Send(model));
}