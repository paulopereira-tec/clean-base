using CleanBase.Business.Features.ToDoItems.CompleteToDoItem;
using CleanBase.Business.Features.ToDoItems.CreateToDoItem;
using CleanBase.Business.Features.ToDoItems.GetToDoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanBase.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ToDoController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ToDoController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Gets all ToDo items.
    /// Obtém todos os itens ToDo.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetToDoItemsQuery());
      if (result.Success)
        return Ok(result.Data);

      return BadRequest(result.Errors);
    }

    /// <summary>
    /// Creates a new ToDo item.
    /// Cria um novo item ToDo.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateToDoItemCommand command)
    {
      var result = await _mediator.Send(command);
      if (result.Success)
        return CreatedAtAction(nameof(GetAll), new { id = result.Data }, result.Data);

      return BadRequest(result.Errors);
    }

    /// <summary>
    /// Marks a ToDo item as complete.
    /// Marca um item ToDo como concluído.
    /// </summary>
    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
      var command = new CompleteToDoItemCommand { Id = id };
      var result = await _mediator.Send(command);

      if (result.Success)
        return NoContent();

      return BadRequest(result.Errors);
    }
  }
}
