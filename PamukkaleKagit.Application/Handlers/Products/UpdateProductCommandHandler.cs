using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.Products;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<ProductResponse>>
    {
        private readonly IProductRepository _repo;

        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Product>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<ProductResponse>(newmodel);

            return new SuccessApiResponse<ProductResponse>(response);
        }
    }
}
