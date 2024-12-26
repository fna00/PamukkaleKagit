using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.CategoriesImages;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;

namespace PamukkaleKagit.Application.Handlers.CategoriesImages
{
    public class CreateCategoryImageCommandHandler : IRequestHandler<CreateCategoryImageCommand, ApiResponse<CategoryImageResponse>>
    {
        private readonly ICategoryImageRepository _repo;
        private readonly IMapper _mapper;

        public CreateCategoryImageCommandHandler
            (ICategoryImageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryImageResponse>> Handle(CreateCategoryImageCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<CategoryImage>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<CategoryImageResponse>(newmodel);

            return new SuccessApiResponse<CategoryImageResponse>(response);
        }
    }
}
