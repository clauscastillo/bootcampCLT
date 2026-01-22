namespace bootcampCLT.Application.Productos.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

public class GetProductosHandler : IRequestHandler<GetProductosQuery, List<ProductoDto>>
{
    private readonly ApplicationDbContext _context;

    public GetProductosHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductoDto>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Productos
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
            .ToListAsync(cancellationToken);
    }
}
