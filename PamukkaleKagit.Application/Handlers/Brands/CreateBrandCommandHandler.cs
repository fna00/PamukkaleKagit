﻿using AutoMapper;
using MediatR;
using PamukkaleKagit.Application.Commands.Brands;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Brands;

namespace PamukkaleKagit.Application.Handlers.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ApiResponse<BrandResponse>>
    {
        private readonly IBrandRepository _repo;

        private readonly IMapper _mapper;

        public CreateBrandCommandHandler
            (IBrandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<BrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Brand>(request);
            var newmodel = await _repo.CreateAsync(model);
            var response = _mapper.Map<BrandResponse>(newmodel);

            return new SuccessApiResponse<BrandResponse>(response);
        }
    }
}
