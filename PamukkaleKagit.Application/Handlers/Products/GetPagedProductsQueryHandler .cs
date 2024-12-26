using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Products;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Domain.Response.PaginatedList;
using PamukkaleKagit.Infrastructure.Repositories;
using PamukkaleKagit.Models.ResponseModels.Products;

namespace PamukkaleKagit.Application.Handlers.Products
{
    public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResponse<Product>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetPagedProductsQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

         async Task<PagedResponse<Product>> IRequestHandler<GetPagedProductsQuery, PagedResponse<Product>>.Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
         {
            var predicate = request.Predicate ?? (x => true);

            var result = await _repo.GetPagedResponseAsync(
                request.PageNumber,
                request.PageSize,
                predicate
            );

            return result;
        }
    }
}
