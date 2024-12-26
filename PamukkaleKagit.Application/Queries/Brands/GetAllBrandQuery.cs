using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Brands;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.Brands
{
    public record GetAllBrandQuery(Expression<Func<Brand, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<BrandResponse>>>;
}
