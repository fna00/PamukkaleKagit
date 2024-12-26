using MediatR;
using PamukkaleKagit.Application.Commands.Brands;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Handlers.Brands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ApiResponse>
    {
        private readonly IBrandRepository _repo;

        public DeleteBrandCommandHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var model = await _repo.GetAsync(I => I.Id == request.Id);

            var result = await _repo.DeleteAsync(model);

            if (!result)
                return new ErrorApiResponse();

            return new SuccessApiResponse(); ;
        }
    }
}
