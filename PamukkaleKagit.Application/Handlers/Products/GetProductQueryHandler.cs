using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.Products;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductyQuery, ApiResponse<ProductResponse>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(GetProductyQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<ProductResponse>(model);

            return new SuccessApiResponse<ProductResponse>(response);
        }
    }
}
