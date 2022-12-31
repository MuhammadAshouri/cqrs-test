﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services.Commands.Category.Delete;
using TestApi.Services.Commands.Category.New;
using TestApi.Services.Commands.Category.Update;
using TestApi.Services.Queries.Category;

namespace TestApi.Server.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator Mediator;
    public CategoriesController(IMediator mediator) => Mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetCategories() => Ok(await Mediator.Send(new GetCategoriesQuery()));

    [HttpGet]
    public async Task<IActionResult> GetCategory(int id) =>
        Ok(await Mediator.Send(new GetCategoriesQuery { Id = id }));

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> AddCategory(AddNewCategoryCommand model) => Created("", await Mediator.Send(model));

    [HttpPut]
    //[Authorize]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand model) => Ok(await Mediator.Send(model));

    [HttpDelete]
    //[Authorize]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand model) => Ok(await Mediator.Send(model));
}
