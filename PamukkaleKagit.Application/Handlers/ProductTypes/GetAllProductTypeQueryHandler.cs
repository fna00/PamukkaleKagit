using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.ProductTypes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductTypes
{
    public class GetAllProductTypeQueryHandler : IRequestHandler<GetAllProductTypeQuery, ApiResponse<IEnumerable<ProductTypeResponse>>>
    {
        private readonly IProductTypeRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductTypeQueryHandler(IProductTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductTypeResponse>>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductType> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<ProductTypeResponse>>(model);

            return new SuccessApiResponse<IEnumerable<ProductTypeResponse>>(response);
        }
    }
}
