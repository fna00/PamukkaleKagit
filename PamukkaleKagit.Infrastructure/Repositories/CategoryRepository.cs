﻿using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Infrastructure.Repositories
{
    public class CategoryRepository :GenericRepository<Category> ,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) 
        {
        }
    }
}
