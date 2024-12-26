using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.ProductTypes
{
    public class UpdateProductTypeCommand : IRequest<ApiResponse<ProductTypeResponse>>
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int TypeId { get; set; }
    }
}
