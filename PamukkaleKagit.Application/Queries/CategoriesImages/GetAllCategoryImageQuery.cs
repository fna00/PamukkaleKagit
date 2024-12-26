using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;
using System.Linq.Expressions;

namespace PamukkaleKagit.Application.Queries.CategoriesImages
{
    public record GetAllCategoryImageQuery(Expression<Func<CategoryImage, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<CategoryImageResponse>>>;
}
