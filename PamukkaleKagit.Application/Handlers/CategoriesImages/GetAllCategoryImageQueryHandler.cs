using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.CategoriesImages;
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
    public class GetAllCategoryImageQueryHandler : IRequestHandler<GetAllCategoryImageQuery, ApiResponse<IEnumerable<CategoryImageResponse>>>
    {
        private readonly ICategoryImageRepository _repo;
        private readonly IMapper _mapper;

        public GetAllCategoryImageQueryHandler(ICategoryImageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CategoryImageResponse>>> Handle(GetAllCategoryImageQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CategoryImage> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<CategoryImageResponse>>(model);

            return new SuccessApiResponse<IEnumerable<CategoryImageResponse>>(response);
        }
    }
}
