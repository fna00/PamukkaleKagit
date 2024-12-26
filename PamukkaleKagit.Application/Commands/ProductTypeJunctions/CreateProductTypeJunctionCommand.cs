using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.ProductTypeJunctions
{
    public class CreateProductTypeJunctionCommand : IRequest<ApiResponse<ProductTypeJunctionResponse>>
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
    }
}
