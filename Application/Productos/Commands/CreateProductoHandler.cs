namespace bootcampCLT.Application.Productos.Commands;
using bootcampCLT.Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

public class CreateProductoHandler : IRequestHandler<CreateProductoCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateProductoHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
    {
        var producto = new Producto
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.Precio,
            CategoriaId = request.CategoriaId,
            CantidadStock = request.CantidadStock,
            Activo = true,
            FechaCreacion = DateTime.UtcNow
        };

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync(cancellationToken);

        return producto.Id;
    }
}
