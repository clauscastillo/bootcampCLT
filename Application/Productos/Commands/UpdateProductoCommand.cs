namespace bootcampCLT.Application.Productos.Commands;

using MediatR;

public record UpdateProductoCommand(
    int Id,
    string Codigo,
    string Nombre,
    string Descripcion,
    decimal Precio,
    int CategoriaId,
    int CantidadStock,
    bool Activo
) : IRequest<bool>; // Devuelve true si se actualizó