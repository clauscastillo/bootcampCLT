namespace bootcampCLT.Application.Productos.Commands;
using MediatR;

public record CreateProductoCommand(
    string Codigo,
    string Nombre,
    string Descripcion,
    decimal Precio,
    int CategoriaId,
    int CantidadStock
) : IRequest<int>;
