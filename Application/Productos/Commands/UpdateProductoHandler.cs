namespace bootcampCLT.Application.Productos.Commands;
using MediatR;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class UpdateProductoHandler : IRequestHandler<UpdateProductoCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateProductoHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {
        var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (producto == null) return false;

        producto.Codigo = request.Codigo;
        producto.Nombre = request.Nombre;
        producto.Descripcion = request.Descripcion;
        producto.Precio = request.Precio;
        producto.CategoriaId = request.CategoriaId;
        producto.CantidadStock = request.CantidadStock;
        producto.Activo = request.Activo;
        producto.FechaActualizacion = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
