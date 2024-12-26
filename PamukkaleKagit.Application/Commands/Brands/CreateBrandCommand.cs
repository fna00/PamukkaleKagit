using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Brands
{
    public class CreateBrandCommand : IRequest<ApiResponse<BrandResponse>>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
