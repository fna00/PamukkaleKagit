using MediatR;
using Microsoft.AspNetCore.Http;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Brands;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Types
{
    public class CreateTypeCommand : IRequest<ApiResponse<TypeResponse>>
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
