using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.ProductAttributes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
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
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand, ApiResponse<ProductAttributeResponse>>
    {
        private readonly IProductAttributeRepository _repo;

        private readonly IMapper _mapper;

        public UpdateProductAttributeCommandHandler(IProductAttributeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductAttributeResponse>> Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductAttribute>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<ProductAttributeResponse>(newmodel);

            return new SuccessApiResponse<ProductAttributeResponse>(response);
        }
    }
}
