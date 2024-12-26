using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;

namespace PamukkaleKagit.Application.Commands.Types
{
    public class UpdateTypeCommand : IRequest<ApiResponse<TypeResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
