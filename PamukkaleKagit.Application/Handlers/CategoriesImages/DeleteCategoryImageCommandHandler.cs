using MediatR;
using PamukkaleKagit.Application.Commands.CategoriesImages;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.CategoriesImages
{
    public class DeleteCategoryImageCommandHandler : IRequestHandler<DeleteCategoryImageCommand, ApiResponse>
    {
        private readonly ICategoryImageRepository _repo;

        public DeleteCategoryImageCommandHandler(ICategoryImageRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteCategoryImageCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if (!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse();
        }
    }
}
