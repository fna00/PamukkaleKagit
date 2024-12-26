using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Brands;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.Brands
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, ApiResponse<IEnumerable<BrandResponse>>>
    {
        private readonly IBrandRepository _repo;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IBrandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<BrandResponse>>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Brand> model = await _repo.GetAllAsync(request.predicate, request.includes);
            var responses = _mapper.Map<IEnumerable<BrandResponse>>(model);
            return new SuccessApiResponse<IEnumerable<BrandResponse>>(responses);
        }
    }
}
