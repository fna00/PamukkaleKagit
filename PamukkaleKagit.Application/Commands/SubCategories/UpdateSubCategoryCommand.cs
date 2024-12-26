﻿using MediatR;
using PamukkaleKagit.Application.Responses;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Commands.SubCategories
{
    public class UpdateSubCategoryCommand : IRequest<ApiResponse<SubCategoryResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}