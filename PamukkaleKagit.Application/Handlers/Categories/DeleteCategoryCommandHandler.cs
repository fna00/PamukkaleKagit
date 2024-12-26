using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;

namespace PamukkaleKagit.Application.Handlers.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse>
    {
        private readonly ICategoryRepository _repo;

        public DeleteCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if(!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse();
        }
    }
}
