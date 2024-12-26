using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.ProductTypeJunctions;
using PamukkaleKagit.Application.Queries.ProductTypeJunctions;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeJunctionController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public ProductTypeJunctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Queries
        [HttpGet("gets/productId")]
        public async Task<ActionResult<IEnumerable<ProductTypeJunctionResponse>>> GetsByproductId([FromQuery] int id = 0)
        {
            Expression<Func<ProductTypeJunction, bool>> predicate = x => x.ProductId == id ;
            var includes = new[] { "Product" , "ProductType" };

            var query = new GetAllProductTypeJunctionQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/producttypesId")]
        public async Task<ActionResult<IEnumerable<ProductTypeJunctionResponse>>> GetsByproducTypetId([FromQuery] int id = 0)
        {
            Expression<Func<ProductTypeJunction, bool>> predicate = x => x.ProductTypeId == id;
            var includes = new[] { "Product", "ProductType" };

            var query = new GetAllProductTypeJunctionQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<ProductTypeJunctionResponse>> GetById(int id)
        {
            Expression<Func<ProductTypeJunction, bool>> predicate = x => x.Id == id;
            var query = new GetProductTypeJunctionQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //Commands
        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateProductTypeJunctionCommand entity)
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
        public async Task<IActionResult> Put(UpdateProductTypeJunctionCommand entity)
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
        public async Task<IActionResult> Delete(DeleteProductTypeJunctionCommand entity)
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
