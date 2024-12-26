using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.ProductTypes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;

namespace PamukkaleKagit.Application.Handlers.ProductTypes
{
    public class GetProductTypeQueryHandler : IRequestHandler<GetProductTypeQuery, ApiResponse<ProductTypeResponse>>
    {
        private readonly IProductTypeRepository _repo;
        private readonly IMapper _mapper;

        public GetProductTypeQueryHandler(IProductTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductTypeResponse>> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<ProductTypeResponse>(model);

            return new SuccessApiResponse<ProductTypeResponse>(response);
        }
    }
}
