using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.ProductAttributes
{
    public class CreateProductAttributeCommand : IRequest<ApiResponse<ProductAttributeResponse>>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
    }
}
