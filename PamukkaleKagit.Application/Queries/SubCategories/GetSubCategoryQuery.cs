using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.SubCategories
{
    public record GetSubCategoryQuery(Expression<Func<SubCategory, bool>> predicate = null) : IRequest<ApiResponse<SubCategoryResponse>>;
}
