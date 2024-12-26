using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application;
using PamukkaleKagit.Application.Commands.Products;
using PamukkaleKagit.Application.Queries.Products;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Products;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Queries
        [HttpGet("gets/products")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetsByName(string? name = null)
        {
            Expression<Func<Product, bool>> predicate = x => string.IsNullOrEmpty(name) || x.Name.Contains(name);
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetAllProductQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        //[HttpGet("GetAllWithPaging")]
        //public async Task<IActionResult> GetAllWithPaging(
        //    [FromQuery] int page = 1,
        //    [FromQuery] int pageSize = 10,
        //    [FromQuery] string name = null)
        //{
        //    Expression<Func<Product, bool>> predicate = null;
        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        predicate = x => x.Name.Contains(name);
        //    }
        //    var includes = new[]
        //    {
        //        "SubCategory",
        //        "Brand",
        //        "ProductTypes",
        //        "ProductAttributes" ,
        //        "ProductTypes.ProductType"
        //    };

        //    var query = new GetPagedProductsQuery(page, pageSize, predicate, includes);
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpPost("PostAllWithPaginaiton")]
        public async Task<IActionResult> PostAllWithPaginaiton(PostAllWithPagingRequest request)
        {
            Expression<Func<Product, bool>> predicate = null;

            if (request.name != null)
                predicate = predicate.Or(x => x.Name.Contains(request.name));

            if (request.subCategoryId.HasValue)
                predicate = predicate.And(x => x.SubCategoryId == request.subCategoryId);

            if (request.packageCount.HasValue)
                predicate = predicate.Or(x => x.Package == request.packageCount);

            if (request.brandId != null && request.brandId.Count > 0)
            {
                Expression<Func<Product, bool>> brandPredicate = null;
                foreach (var brandId in request.brandId)
                {
                    brandPredicate = brandPredicate.Or(x => x.BrandId == brandId);
                }
                predicate = predicate.Or(brandPredicate);
            }
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetPagedProductsQuery(request.page, request.pageSize, predicate);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //[HttpPost("post/ByFilterAnd")]
        //public async Task<ActionResult<IEnumerable<ProductResponse>>> PostByFilterAnd(GetAllByFilterQuery request)
        //{
        //    Expression<Func<Product, bool>> predicate = null;

        //    if (request.Name != null)
        //        predicate = predicate.And(x => x.Name.Contains(request.Name));

        //    if (request.SubCategoryId.HasValue)
        //        predicate = predicate.And(x => x.SubCategoryId == request.SubCategoryId);

        //    if (request.PackageCount.HasValue)
        //        predicate = predicate.And(x => x.Package == request.PackageCount);

        //    if (request.BrandId != null && request.BrandId.Count > 0)
        //    {
        //        Expression<Func<Product, bool>> brandPredicate = null;
        //        foreach (var brandId in request.BrandId)
        //        {
        //            brandPredicate = brandPredicate.Or(x => x.BrandId == brandId);
        //        }
        //        predicate = predicate.And(brandPredicate);
        //    }

        //    var includes = new[]
        //    {
        //        "SubCategory",
        //        "Brand",
        //        "ProductTypes",
        //        "ProductAttributes" ,
        //        "ProductTypes.ProductType"
        //    };

        //    var query = new GetAllProductQuery(predicate, includes);
        //    var entities = await _mediator.Send(query);
        //    return Ok(entities);
        //}

        //[HttpPost("post/ByFilterOr")]
        //public async Task<ActionResult<IEnumerable<ProductResponse>>> PostByFilterOr(GetAllByFilterQuery request)
        //{
        //    Expression<Func<Product, bool>> predicate = null;

        //    if (request.Name != null)
        //        predicate = predicate.Or(x => x.Name.Contains(request.Name));

        //    if (request.SubCategoryId.HasValue)
        //        predicate = predicate.Or(x => x.SubCategoryId == request.SubCategoryId);

        //    if (request.PackageCount.HasValue)
        //        predicate = predicate.Or(x => x.Package == request.PackageCount);

        //    if (request.BrandId != null && request.BrandId.Count > 0)
        //    {
        //        Expression<Func<Product, bool>> brandPredicate = null;
        //        foreach (var brandId in request.BrandId)
        //        {
        //            brandPredicate = brandPredicate.Or(x => x.BrandId == brandId);
        //        }
        //        predicate = predicate.Or(brandPredicate);
        //    }

        //    var includes = new[]
        //    {
        //        "SubCategory",
        //        "Brand",
        //        "ProductTypes",
        //        "ProductAttributes" ,
        //        "ProductTypes.ProductType"
        //    };

        //    var query = new GetAllProductQuery(predicate, includes);
        //    var entities = await _mediator.Send(query);
        //    return Ok(entities);
        //}

        [HttpGet("gets/active")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetsByisActive([FromQuery] bool active)
        {
            Expression<Func<Product, bool>> predicate = x => x.IsActive == active;
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetAllProductQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/selected")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetsByourSelected([FromQuery] bool selected = true)
        {
            Expression<Func<Product, bool>> predicate = x => x.OurSelected == selected;
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetAllProductQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/brandId")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetsByBrandId([FromQuery] int id)
        {
            Expression<Func<Product, bool>> predicate = x => x.BrandId == id;
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetAllProductQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/subcategoryId")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetsBySubCategoryId([FromQuery] int id)
        {
            Expression<Func<Product, bool>> predicate = x => x.SubCategoryId == id;
            var includes = new[]
            {
                "SubCategory",
                "Brand",
                "ProductTypes",
                "ProductAttributes" ,
                "ProductTypes.ProductType"
            };

            var query = new GetAllProductQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<ProductResponse>> GetById(int id)
        {
            Expression<Func<Product, bool>> predicate = x => x.Id == id;
            var query = new GetProductyQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<ProductResponse>> GetByName(string name)
        {
            Expression<Func<Product, bool>> predicate = x => x.Name == name;
            var query = new GetProductyQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //Commands
        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateProductCommand entity)
        {
            if (entity == null)
            {
                return BadRequest();  // Return 400 if the entity is null
            }
            var result = await _mediator.Send(entity);

            if (result != null)
                return Ok(result);
            return Accepted();
        }

        [HttpPut("put")]
        public async Task<IActionResult> Put(UpdateProductCommand entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(entity);

            if (result != null)
                return Ok(result);
            return Accepted();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteProductCommand entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(entity);

            if (result != null)
                return Ok(result);
            return Accepted();
        }
    }
}
