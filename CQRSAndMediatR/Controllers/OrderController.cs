using Application.Commands;
using Application.Queries;
using Domain.Entities;
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

    [HttpGet]
    public async Task<Order> Get(int id)
    {
        var result = await _mediator.Send(new GetOrderQuery(id));

        return result;
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(
        int orderId,
        [FromBody] UpdateOrderDto dto)
    {
        var command = new UpdateOrderCommand(
            orderId,          
            dto.ProductName,
            dto.UserId,
            dto.TotalAmount
        );

        var success = await _mediator.Send(command);

        if (!success)
            return NotFound();

        return Ok("Order is successfully updated!");
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        var command = new DeleteOrderCommand(orderId);
        var success = await _mediator.Send(command);

        if (!success)
            return NotFound();

        return Ok("Order is deleted");
    }
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetOrdersByUser(int userId)
    {
        var query = new GetOrdersByUserIdQuery(userId);
        var orders = await _mediator.Send(query);

        if (orders.Count == 0)
            return NotFound();

        return Ok(orders);
    }



}
