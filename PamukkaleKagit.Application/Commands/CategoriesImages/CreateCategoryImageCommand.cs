using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;

namespace PamukkaleKagit.Application.Commands.CategoriesImages
{
    public class CreateCategoryImageCommand : IRequest<ApiResponse<CategoryImageResponse>>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}