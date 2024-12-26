using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Products;

namespace PamukkaleKagit.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<ApiResponse<ProductResponse>>
    {
        public int Id { get; set; }
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
