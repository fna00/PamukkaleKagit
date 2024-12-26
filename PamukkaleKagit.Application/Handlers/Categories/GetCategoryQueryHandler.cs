using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;

namespace PamukkaleKagit.Application.Handlers.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ApiResponse<CategoryResponse>>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            
            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<CategoryResponse>(model);

            return new SuccessApiResponse<CategoryResponse>(response);
        }
    }
}
