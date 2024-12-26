using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductAttributeRepository _productAttributesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeJunctionRepository _productTypeJuctionRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _categoryRepository = new CategoryRepository(_context);
            _productAttributesRepository = new ProductAttributeRepository(_context);
            _productRepository = new ProductRepository(_context);
            _productTypeJuctionRepository = new ProductTypeJunctionRepository(_context);
            _productTypeRepository = new ProductTypeRepository(_context);
            _subCategoryRepository = new SubCategoryRepository(_context);
            _typeRepository = new TypeRepository(_context);
            _userRepository = new UserRepository(_context);
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IProductAttributeRepository ProductAttributesRepository => _productAttributesRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IProductTypeJunctionRepository ProductTypeJuctionRepository => _productTypeJuctionRepository;
        public IProductTypeRepository ProductTypeRepository => _productTypeRepository;
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository;
        public ITypeRepository TypeRepository => _typeRepository;
        public IUserRepository UserRepository => _userRepository;

        //public CategoryRepository CategoryRepository { get; private set; }
        //public ProductAttributeRepository ProdProductAttributeRepositoryuctRepository { get; private set; }
        //public ProductRepository ProductRepository { get; private set; }
        //public ProductTypeJuctionRepository ProductTypeJuctionRepository { get; private set; }
        //public ProductTypeRepository ProductTypeRepository { get; private set; }
        //public SubCategoryRepository SubCategoryRepository { get; private set; }
        //public TypeRepository TypeRepository { get; private set; }
        //public UserRepository UserRepository { get; private set; }

        public async Task Complete()
        {
            using (var trans = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await trans.CommitAsync();
                }
                catch
                {
                    await trans.RollbackAsync();
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
