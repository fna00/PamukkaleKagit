using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.ProductAttributes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;

namespace PamukkaleKagit.Application.Handlers.ProductAttributes
{
    public class GetAllProductAttributeQueryHandler : IRequestHandler<GetAllProductAttributesQuery, ApiResponse<IEnumerable<ProductAttributeResponse>>>
    {
        private readonly IProductAttributeRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductAttributeQueryHandler(IProductAttributeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductAttributeResponse>>> Handle(GetAllProductAttributesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductAttribute> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<ProductAttributeResponse>>(model);

            return new SuccessApiResponse<IEnumerable<ProductAttributeResponse>>(response);
        }
    }
}
