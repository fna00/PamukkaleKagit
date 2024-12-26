using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Brands
{
    public class DeleteBrandCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
