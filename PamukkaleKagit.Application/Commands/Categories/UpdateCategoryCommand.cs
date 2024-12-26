using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;

namespace PamukkaleKagit.Application.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<ApiResponse<CategoryResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
