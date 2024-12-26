using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.ProductTypes
{
    public record GetAllProductTypeQuery(Expression<Func<ProductType, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<ProductTypeResponse>>>;
}
