using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.ProductTypeJunctions;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductTypeJunctions
{
    public class GetAllProductTypeJunctionQueryHandler : IRequestHandler<GetAllProductTypeJunctionQuery, ApiResponse<IEnumerable<ProductTypeJunctionResponse>>>
    {
        private readonly IProductTypeJunctionRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductTypeJunctionQueryHandler(IProductTypeJunctionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductTypeJunctionResponse>>> Handle(GetAllProductTypeJunctionQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductTypeJunction> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<ProductTypeJunctionResponse>>(model);

            return new SuccessApiResponse<IEnumerable<ProductTypeJunctionResponse>>(response);
        }
    }
}
