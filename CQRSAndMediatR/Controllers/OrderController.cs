using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CQRSAndMediatR.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpGet("{id}")]
    //[SwaggerOperation(Summary = "Return orders ID", Description = "Fetches all order IDs from the system.")]

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}
