using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.Categories
{
    //public record GetAllCategoryQuery(Expression<Func<Category, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<CategoryResponse>>>;
    public record GetAllCategoryQuery(
    Expression<Func<Category, bool>> predicate = null,
    string[] includes = null,
    Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null
    ) : IRequest<ApiResponse<IEnumerable<CategoryResponse>>>;
}
