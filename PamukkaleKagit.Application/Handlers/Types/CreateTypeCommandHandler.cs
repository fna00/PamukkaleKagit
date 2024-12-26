using MediatR;
using AutoMapper;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Types;
using Type = PamukkaleKagit.Domain.Entities.Type;
using PamukkaleKagit.Application.Commands.Types;


namespace PamukkaleKagit.Application.Handlers.Types
{
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, ApiResponse<TypeResponse>>
    {
        private readonly ITypeRepository _repo;
        private readonly IMapper _mapper;

        public CreateTypeCommandHandler(ITypeRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TypeResponse>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Type>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<TypeResponse>(newmodel);

            return new SuccessApiResponse<TypeResponse>(response);
        }
    }
}
