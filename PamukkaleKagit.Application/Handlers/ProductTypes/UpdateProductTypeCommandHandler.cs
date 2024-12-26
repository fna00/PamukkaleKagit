using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.ProductTypes;
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
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, ApiResponse<ProductTypeResponse>>
    {
        private readonly IProductTypeRepository _repo;

        private readonly IMapper _mapper;

        public UpdateProductTypeCommandHandler(IProductTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductTypeResponse>> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductType>(request);
            var newmodel = await _repo. UpdateAsync(model.Id, model);
            var response = _mapper.Map<ProductTypeResponse>(newmodel);

            return new SuccessApiResponse<ProductTypeResponse>(response);
        }
    }
}
