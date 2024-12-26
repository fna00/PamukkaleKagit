using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
namespace PamukkaleKagit.Application.Handlers.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse<CategoryResponse>>
    {
        private readonly ICategoryRepository _repo;

        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Category>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<CategoryResponse>(newmodel);

            return new SuccessApiResponse<CategoryResponse>(response);
        }
    }
}
