using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<ApiResponse<ProductResponse>>
    {
        public string Name { get; set; }
        public int Package { get; set; }
        public int Box { get; set; }
        public bool IsActive { get; set; }
        public bool OurSelected { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public string Image { get; set; }
    }
}
