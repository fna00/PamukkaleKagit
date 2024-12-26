using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.SubCategories;
using PamukkaleKagit.Application.Responses;
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
    public class GetSubCategoryQueryHandler : IRequestHandler<GetSubCategoryQuery, ApiResponse<SubCategoryResponse>>
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IMapper _mapper;

        public GetSubCategoryQueryHandler(ISubCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SubCategoryResponse>> Handle(GetSubCategoryQuery request, CancellationToken cancellationToken)
        {

            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<SubCategoryResponse>(model);

            return new SuccessApiResponse<SubCategoryResponse>(response);
        }
    }
}
