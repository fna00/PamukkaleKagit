using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.CategoriesImages
{
    public record GetCategoryImageQuery(Expression<Func<CategoryImage, bool>> predicate = null) : IRequest<ApiResponse<CategoryImageResponse>>;
}
