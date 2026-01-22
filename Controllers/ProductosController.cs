
using bootcampCLT.Application.Productos.Commands;
using bootcampCLT.Application.Productos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bootcampCLT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductosController> _logger;

    public ProductosController(IMediator mediator, ILogger<ProductosController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    // GET /api/productos
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _mediator.Send(new GetProductosQuery());
        return Ok(productos);
    }

    // GET /api/productos/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _mediator.Send(new GetProductoByIdQuery(id));
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    // POST /api/productos
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    // PUT /api/productos/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductoCommand command)
    {
        if (id != command.Id) return BadRequest();
        var result = await _mediator.Send(command);
        if (!result) return NotFound();
        return NoContent();
    }

    // DELETE /api/productos/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductoCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
}
