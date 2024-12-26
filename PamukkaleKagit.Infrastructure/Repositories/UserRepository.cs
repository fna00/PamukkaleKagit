﻿using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Infrastructure.Repositories
{
    public class UserRepository :GenericRepository<User> , IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) 
        { 
        }
    }
}
