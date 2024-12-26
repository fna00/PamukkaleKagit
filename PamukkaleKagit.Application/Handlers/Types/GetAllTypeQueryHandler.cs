using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.Types;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Application.Handlers.Types
{
    public class GetAllTypeQueryHandler : IRequestHandler<GetAllTypeQuery, ApiResponse<IEnumerable<TypeResponse>>>
    {
        private readonly ITypeRepository _repo;
        private readonly IMapper _mapper;

        public GetAllTypeQueryHandler(ITypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TypeResponse>>> Handle(GetAllTypeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Type> model = await _repo.GetAllAsync(request.predicate, request.includes);

            var response = _mapper.Map<IEnumerable<TypeResponse>>(model);

            return new SuccessApiResponse<IEnumerable<TypeResponse>>(response);
        }
    }
}
