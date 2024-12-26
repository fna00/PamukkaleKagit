using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.Types;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;

namespace PamukkaleKagit.Application.Handlers.Types
{
    public class DeleteTypeCommandHandler :IRequestHandler<DeleteTypeCommand, ApiResponse>
    {
        private readonly ICategoryRepository _repo;

        public DeleteTypeCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if(!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse();
        }
    }
}
