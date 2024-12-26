using AutoMapper;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Brands;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;
using PamukkaleKagit.Models.ResponseModels.Products;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using PamukkaleKagit.Models.ResponseModels.Types;
using Type = PamukkaleKagit.Domain.Entities.Type;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.Brands;
using PamukkaleKagit.Application.Commands.CategoriesImages;
using PamukkaleKagit.Application.Commands.Products;
using PamukkaleKagit.Application.Commands.ProductAttributes;
using PamukkaleKagit.Application.Commands.ProductTypes;
using PamukkaleKagit.Application.Commands.ProductTypeJunctions;
using PamukkaleKagit.Application.Commands.Types;
using PamukkaleKagit.Application.Commands.SubCategories;

namespace PamukkaleKagit.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Brand
            CreateMap<Brand, BrandResponse>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();/*.ForMember(x=>x.Icon,map=>map.MapFrom(x=>x.Icooooon))*/

            //Category
            CreateMap<Category, CategoryResponse>()
                .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            //Category Image
            CreateMap<CategoryImage, CategoryImageResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(r => r.Category != null ? r.Category.Name : ""))
                .ReverseMap();
            CreateMap<CategoryImage, CreateCategoryImageCommand>().ReverseMap();
            CreateMap<CategoryImage,  UpdateCategoryImageCommand>().ReverseMap();

            //Product
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductTypes, opt => opt.MapFrom(src => src.ProductTypes))
                .ForMember(dest => dest.ProductAttributes, opt => opt.MapFrom(src => src.ProductAttributes))
                .ForMember(x => x.BrandName, opt => opt.MapFrom(r => r.Brand != null ? r.Brand.Name : ""))
                .ForMember(x => x.SubCategoryName, opt => opt.MapFrom(r => r.SubCategory != null ? r.SubCategory.Name : ""))
                .ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

            //Product Attirbute
            CreateMap<ProductAttribute, ProductAttributeResponse>()
                .ForMember(x => x.ProductName, opt => opt.MapFrom(r => r.Product != null ? r.Product.Name : ""))
                .ReverseMap();
            CreateMap<ProductAttribute, CreateProductAttributeCommand>().ReverseMap();
            CreateMap<ProductAttribute,  UpdateProductAttributeCommand>().ReverseMap();

            //Product Type
            CreateMap<ProductType, ProductTypeResponse>()
                .ForMember(x => x.TypeName, opt => opt.MapFrom(r => r.Type != null ? r.Type.Name : ""))
                .ReverseMap();
            CreateMap<ProductType, CreateProductTypeCommand>().ReverseMap();
            CreateMap<ProductType, UpdateProductTypeCommand>().ReverseMap();

            //Product Type Junction
            CreateMap<ProductTypeJunction, ProductTypeJunctionResponse>()
                .ForMember(x => x.ProductName, opt => opt.MapFrom(r => r.Product != null ? r.Product.Name : ""))
                .ForMember(x => x.ProductTypeText, opt => opt.MapFrom(r => r.ProductType != null ? r.ProductType.Text : ""))
                .ForMember(x => x.ProductTypeValue, opt => opt.MapFrom(r => r.ProductType != null ? r.ProductType.Value : ""))
                .ReverseMap();
            CreateMap<ProductTypeJunction, CreateProductTypeJunctionCommand>().ReverseMap();
            CreateMap<ProductTypeJunction, UpdateProductTypeJunctionCommand>().ReverseMap();

            //Type
            CreateMap<Type, TypeResponse>().ReverseMap();
            CreateMap<Type, CreateTypeCommand>().ReverseMap();
            CreateMap<Type, UpdateTypeCommand>().ReverseMap();

            //SubCategory
            CreateMap<SubCategory, SubCategoryResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(r => r.Category != null ? r.Category.Name : ""))
                .ReverseMap();
            CreateMap<SubCategory, CreateSubCategoryCommand>().ReverseMap();
            CreateMap<SubCategory, UpdateSubCategoryCommand>().ReverseMap();
        }
    }
}
