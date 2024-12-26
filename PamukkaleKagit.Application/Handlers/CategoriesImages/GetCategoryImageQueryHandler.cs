using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.CategoriesImages;
using PamukkaleKagit.Application.Responses;
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
    public class GetCategoryImageQueryHandler : IRequestHandler<GetCategoryImageQuery, ApiResponse<CategoryImageResponse>>
    {
        private readonly ICategoryImageRepository _repo;
        private readonly IMapper _mapper;

        public GetCategoryImageQueryHandler(ICategoryImageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryImageResponse>> Handle(GetCategoryImageQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<CategoryImageResponse>(model);

            return new SuccessApiResponse<CategoryImageResponse>(response);
        }
    }
}
