using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Products;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Products;

namespace PamukkaleKagit.Application.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>
    {
        private readonly IProductRepository _repo;

        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Product>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<ProductResponse>(newmodel);

            return new SuccessApiResponse<ProductResponse>(response);
        }
    }
}
