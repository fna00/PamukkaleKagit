using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Products;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Products;

namespace PamukkaleKagit.Application.Handlers.Products
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ApiResponse<IEnumerable<ProductResponse>>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<ProductResponse>>(model);

            return new SuccessApiResponse<IEnumerable<ProductResponse>>(response);
        }
    }
}
