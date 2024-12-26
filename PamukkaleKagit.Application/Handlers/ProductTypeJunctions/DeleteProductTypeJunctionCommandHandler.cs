using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.ProductTypeJunctions;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductTypeJunctions
{
    public class DeleteProductTypeJunctionCommandHandler : IRequestHandler<DeleteProductTypeJunctionCommand, ApiResponse>
    {
        private readonly IProductTypeJunctionRepository _repo;

        public DeleteProductTypeJunctionCommandHandler(IProductTypeJunctionRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteProductTypeJunctionCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if (!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse();
        }
    }
}
