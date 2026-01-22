namespace bootcampCLT.Application.Productos.Queries;
using MediatR;

public record GetProductoByIdQuery(int Id) : IRequest<ProductoDto>;
