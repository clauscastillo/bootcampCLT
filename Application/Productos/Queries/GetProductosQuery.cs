namespace bootcampCLT.Application.Productos.Queries;
using bootcampCLT.Application.Productos;
using MediatR;
using System.Collections.Generic;

public record GetProductosQuery() : IRequest<List<ProductoDto>>;