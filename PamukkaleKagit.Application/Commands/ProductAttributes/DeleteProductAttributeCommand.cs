using MediatR;
using PamukkaleKagit.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.ProductAttributes
{
    public class DeleteProductAttributeCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
