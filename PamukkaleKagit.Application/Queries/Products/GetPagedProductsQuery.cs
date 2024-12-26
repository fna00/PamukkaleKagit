using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Response.PaginatedList;
using PamukkaleKagit.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.Products
{
    public record GetPagedProductsQuery : IRequest<PagedResponse<Product>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Expression<Func<Product, bool>>? Predicate { get; set; }

        public GetPagedProductsQuery(int pageNumber, int pageSize, Expression<Func<Product, bool>>? predicate = null, params string[] includes)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Predicate = predicate;
        }
    }
}
