using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.ProductTypeJunctions;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Infrastructure.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductTypeJunctions
{
    public class GetProductTypeJunctionQueryHandler : IRequestHandler<GetProductTypeJunctionQuery, ApiResponse<ProductTypeJunctionResponse>>
    {
        private readonly IProductTypeJunctionRepository _repo;
        private readonly IMapper _mapper;

        public GetProductTypeJunctionQueryHandler(IProductTypeJunctionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductTypeJunctionResponse>> Handle(GetProductTypeJunctionQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<ProductTypeJunctionResponse>(model);

            return new SuccessApiResponse<ProductTypeJunctionResponse>(response);
        }
    }
}
