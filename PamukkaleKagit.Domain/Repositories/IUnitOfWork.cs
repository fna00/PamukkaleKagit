using PamukkaleKagit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductAttributeRepository ProductAttributesRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductTypeJunctionRepository ProductTypeJuctionRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        ITypeRepository TypeRepository { get; }
        IUserRepository UserRepository { get; }
        Task Complete();
        void Dispose();
    }
}
