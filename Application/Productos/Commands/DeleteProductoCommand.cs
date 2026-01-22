namespace bootcampCLT.Application.Productos.Commands;

using MediatR;

public record DeleteProductoCommand(int Id) : IRequest<bool>; // Devuelve true si se eliminó

