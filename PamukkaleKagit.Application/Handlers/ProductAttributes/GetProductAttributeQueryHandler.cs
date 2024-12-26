using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.ProductAttributes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductAttributes
{
    public class GetProductAttributeQueryHandler : IRequestHandler<GetProductAttributesQuery, ApiResponse<ProductAttributeResponse>>
    {
        private readonly IProductAttributeRepository _repo;
        private readonly IMapper _mapper;

        public GetProductAttributeQueryHandler(IProductAttributeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductAttributeResponse>> Handle(GetProductAttributesQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<ProductAttributeResponse>(model);

            return new SuccessApiResponse<ProductAttributeResponse>(response);
        }
    }
}
