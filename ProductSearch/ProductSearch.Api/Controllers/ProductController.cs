using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSearch.Application.Queries;
using ProductSearch.Infrastructure.Base;

namespace ProductSearch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Filters products
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationError[]), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> FilterProducts(FilterProductsQuery query)
    {
        var response = await _mediator.Send(query);

        return Ok(response);
    }
}