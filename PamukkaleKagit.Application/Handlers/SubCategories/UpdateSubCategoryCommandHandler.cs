using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.SubCategories;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.SubCategories
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, ApiResponse<SubCategoryResponse>>
    {
        private readonly ISubCategoryRepository _repo;

        private readonly IMapper _mapper;

        public UpdateSubCategoryCommandHandler(ISubCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SubCategoryResponse>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<SubCategory>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<SubCategoryResponse>(newmodel);

            return new SuccessApiResponse<SubCategoryResponse>(response);
        }
    }
}
