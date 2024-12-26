using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Types;
using System.Linq.Expressions;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Application.Queries.Types
{
    public record GetAllTypeQuery(Expression<Func<Type, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<TypeResponse>>>;
}
