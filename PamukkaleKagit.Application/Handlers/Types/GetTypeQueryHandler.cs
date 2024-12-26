using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.Types;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;

namespace PamukkaleKagit.Application.Handlers.Types
{
    public class GetTypeQueryHandler : IRequestHandler<GetTypeQuery, ApiResponse<TypeResponse>>
    {
        private readonly ITypeRepository _repo;
        private readonly IMapper _mapper;

        public GetTypeQueryHandler(ITypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TypeResponse>> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            
            var model = await _repo.GetAsync(request.predicate);

            var response = _mapper.Map<TypeResponse>(model);

            return new SuccessApiResponse<TypeResponse>(response);
        }
    }
}
