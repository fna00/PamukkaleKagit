using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.SubCategories;
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
    public class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQuery, ApiResponse<IEnumerable<SubCategoryResponse>>>
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IMapper _mapper;

        public GetAllSubCategoryQueryHandler(ISubCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<SubCategoryResponse>>> Handle(GetAllSubCategoryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<SubCategory> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<SubCategoryResponse>>(model);

            return new SuccessApiResponse<IEnumerable<SubCategoryResponse>>(response);
        }
    }
}
