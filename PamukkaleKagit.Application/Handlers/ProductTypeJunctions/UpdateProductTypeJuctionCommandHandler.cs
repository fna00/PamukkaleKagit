using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.ProductTypeJunctions;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductTypeJunctions
{
    public class UpdateProductTypeJuctionCommandHandler : IRequestHandler<UpdateProductTypeJunctionCommand, ApiResponse<ProductTypeJunctionResponse>>
    {
        private readonly IProductTypeJunctionRepository _repo;

        private readonly IMapper _mapper;

        public UpdateProductTypeJuctionCommandHandler(IProductTypeJunctionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductTypeJunctionResponse>> Handle(UpdateProductTypeJunctionCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductTypeJunction>(request);
            var newmodel = await _repo.UpdateAsync(model.Id     ,model);
            var response = _mapper.Map<ProductTypeJunctionResponse>(newmodel);

            return new SuccessApiResponse<ProductTypeJunctionResponse>(response);
        }
    }
}
