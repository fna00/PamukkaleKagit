using PamukkaleKagit.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.Infrastructure.Repositories
{
    public class TypeRepository :GenericRepository<Type> , ITypeRepository
    {
        public TypeRepository(AppDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
