using MediatR;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.ProductAttributes;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.ProductAttributes
{
    public  class DeleteProductAttributeCommandHandler :IRequestHandler<DeleteProductAttributeCommand, ApiResponse>
    {
        private readonly IProductAttributeRepository _repo;

        public DeleteProductAttributeCommandHandler(IProductAttributeRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if (!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse();
        }
    }
}
