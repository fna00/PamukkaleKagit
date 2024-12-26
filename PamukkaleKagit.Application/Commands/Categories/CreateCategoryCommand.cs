using MediatR;
using Microsoft.AspNetCore.Http;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Brands;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.Category
{
    public class CreateCategoryCommand : IRequest<ApiResponse<CategoryResponse>>

    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
