using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.Brands
{
    public record GetBrandQuery(Expression<Func<Brand, bool>> predicate = null) : IRequest<ApiResponse<BrandResponse>>;
}
