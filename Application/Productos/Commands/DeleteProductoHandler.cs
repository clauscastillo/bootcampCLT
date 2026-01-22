namespace bootcampCLT.Application.Productos.Commands;
using MediatR;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class DeleteProductoHandler : IRequestHandler<DeleteProductoCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteProductoHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {
        var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (producto == null) return false;

        // Eliminación lógica
        producto.Activo = false;
        producto.FechaActualizacion = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
