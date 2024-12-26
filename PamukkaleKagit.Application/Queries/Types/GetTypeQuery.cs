using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Types;
using System.Linq.Expressions;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Application.Queries.Types
{
    public record GetTypeQuery(Expression<Func<Type,bool>> predicate = null) : IRequest<ApiResponse<TypeResponse>>;
}
