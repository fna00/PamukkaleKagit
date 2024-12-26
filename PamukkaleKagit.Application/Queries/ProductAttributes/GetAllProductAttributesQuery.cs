using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using System.Linq.Expressions;
namespace PamukkaleKagit.Application.Queries.ProductAttributes
{
    public record GetAllProductAttributesQuery(Expression<Func<ProductAttribute, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<ProductAttributeResponse>>>;
}
