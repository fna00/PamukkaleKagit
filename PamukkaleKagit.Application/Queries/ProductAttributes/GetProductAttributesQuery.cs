using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.ProductAttributes
{
    public record GetProductAttributesQuery(Expression<Func<ProductAttribute, bool>> predicate = null) : IRequest<ApiResponse<ProductAttributeResponse>>;
}
