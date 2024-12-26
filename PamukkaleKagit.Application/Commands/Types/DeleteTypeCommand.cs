using MediatR;
using PamukkaleKagit.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Types
{
    public class DeleteTypeCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
