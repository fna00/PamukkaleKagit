﻿using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.Products
{
    public record GetAllProductQuery(Expression<Func<Product, bool>> predicate = null, string[] includes = null) : IRequest<ApiResponse<IEnumerable<ProductResponse>>>;
}
