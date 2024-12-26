using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.CategoriesImages;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.CategoriesImages
{
    public class UpdateCategoryImageCommandHandler : IRequestHandler<UpdateCategoryImageCommand, ApiResponse<CategoryImageResponse>>
    {
        private readonly ICategoryImageRepository _repo;

        private readonly IMapper _mapper;

        public UpdateCategoryImageCommandHandler (ICategoryImageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryImageResponse>> Handle(UpdateCategoryImageCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<CategoryImage>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<CategoryImageResponse>(newmodel);

            return new SuccessApiResponse<CategoryImageResponse>(response);
        }
    }
}
