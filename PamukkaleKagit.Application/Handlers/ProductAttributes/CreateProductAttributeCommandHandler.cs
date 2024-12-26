using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.ProductAttributes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
namespace PamukkaleKagit.Application.Handlers.ProductAttributes
{
    public class CreateProductAttributeCommandHandler : IRequestHandler<CreateProductAttributeCommand, ApiResponse<ProductAttributeResponse>>
    {
        private readonly IProductAttributeRepository _repo;
        private readonly IMapper _mapper;

        public CreateProductAttributeCommandHandler(IProductAttributeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductAttributeResponse>> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductAttribute>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<ProductAttributeResponse>(newmodel);

            return new SuccessApiResponse<ProductAttributeResponse>(response);
        }
    }
}
