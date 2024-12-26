using MediatR;
using AutoMapper;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Models.ResponseModels.Categories;


namespace PamukkaleKagit.Application.Handlers.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryResponse>>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Category>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<CategoryResponse>(newmodel);

            return new SuccessApiResponse<CategoryResponse>(response);
        }
    }
}
