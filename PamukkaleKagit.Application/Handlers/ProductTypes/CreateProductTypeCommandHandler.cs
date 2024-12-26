using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.ProductTypes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;

namespace PamukkaleKagit.Application.Handlers.ProductTypes
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, ApiResponse<ProductTypeResponse>>
    {
        private readonly IProductTypeRepository _repo;
        private readonly IMapper _mapper;

        public CreateProductTypeCommandHandler(IProductTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductTypeResponse>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductType>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<ProductTypeResponse>(newmodel);

            return new SuccessApiResponse<ProductTypeResponse>(response);
        }
    }
}