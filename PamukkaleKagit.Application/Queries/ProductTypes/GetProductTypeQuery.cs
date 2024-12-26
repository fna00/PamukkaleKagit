using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.ProductTypes
{
    public record GetProductTypeQuery(Expression<Func<ProductType , bool>> predicate = null) : IRequest<ApiResponse<ProductTypeResponse>>;
}
