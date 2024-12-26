using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Brands;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.Brands
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, ApiResponse<BrandResponse>>
    {
        private readonly IBrandRepository _repo;
        private readonly IMapper _mapper;
        public GetBrandQueryHandler(IBrandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<BrandResponse>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(request.predicate);
            var response = _mapper.Map<BrandResponse>(model);
            return new SuccessApiResponse<BrandResponse>(response);
        }
    }
}
