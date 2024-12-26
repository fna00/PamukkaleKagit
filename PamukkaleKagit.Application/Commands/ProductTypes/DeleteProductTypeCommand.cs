using MediatR;
using PamukkaleKagit.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.ProductTypes
{
    public class DeleteProductTypeCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
