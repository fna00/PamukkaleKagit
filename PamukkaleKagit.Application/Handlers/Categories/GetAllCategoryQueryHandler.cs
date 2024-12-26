using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;

namespace PamukkaleKagit.Application.Handlers.Categories
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ApiResponse<IEnumerable<CategoryResponse>>>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

//        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
//        {
//            IEnumerable<Category> model = await _repo.GetAllAsync(request.predicate, request.includes);

//            var response = _mapper.Map<IEnumerable<CategoryResponse>>(model);

//            return new SuccessApiResponse<IEnumerable<CategoryResponse>>(response);
//        }
//    }
//}


        public async Task<ApiResponse<IEnumerable<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {

            var entities = await _repo.GetsAsync(
                request.predicate,
                request.includes,
                request.orderBy);

            foreach (var category in entities)
            {
                category.SubCategories = category.SubCategories
                    .OrderBy(sub => sub.Name)
                    .ToList();
            }

            var response = _mapper.Map<IEnumerable<CategoryResponse>>(entities);

            return new SuccessApiResponse<IEnumerable<CategoryResponse>>(response);
        }
    }
}
