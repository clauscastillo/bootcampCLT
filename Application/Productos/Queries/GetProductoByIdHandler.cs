namespace bootcampCLT.Application.Productos.Queries;

using MediatR;
using Microsoft.EntityFrameworkCore;
using bootcampCLT.Infrastructure.Persistence;

public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoDto>
{
    private readonly ApplicationDbContext _context;

    public GetProductoByIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductoDto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
    {
        var producto = await _context.Productos
            .Where(p => p.Id == request.Id)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Activo = p.Activo,
                CategoriaId = p.CategoriaId,
                CantidadStock = p.CantidadStock
            })
            .FirstOrDefaultAsync(cancellationToken);

        return producto; // puede devolver null si no existe
    }
}
