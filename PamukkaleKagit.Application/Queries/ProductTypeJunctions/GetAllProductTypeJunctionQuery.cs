using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.ProductTypeJunctions
{
    public record GetAllProductTypeJunctionQuery(Expression<Func<ProductTypeJunction, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<ProductTypeJunctionResponse>>>;
}
