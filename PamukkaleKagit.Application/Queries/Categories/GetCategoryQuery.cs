using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.Categories
{
    public record GetCategoryQuery(Expression<Func<Category,bool>> predicate = null) : IRequest<ApiResponse<CategoryResponse>>;
}
