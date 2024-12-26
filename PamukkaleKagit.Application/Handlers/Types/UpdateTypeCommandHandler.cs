using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.Types;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Application.Handlers.Types
{
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand, ApiResponse<TypeResponse>>
    {
        private readonly ITypeRepository _repo;

        private readonly IMapper _mapper;

        public UpdateTypeCommandHandler (ITypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TypeResponse>> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Type>(request);
            var newmodel = await _repo.UpdateAsync(model.Id, model);
            var response = _mapper.Map<TypeResponse>(newmodel);

            return new SuccessApiResponse<TypeResponse>(response);
        }
    }
}
