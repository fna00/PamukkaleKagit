using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.ProductAttributes;
using PamukkaleKagit.Application.Queries.ProductAttributes;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IMediator _mediator = null;

        public ProductAttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gets/name")]
        public async Task<ActionResult<IEnumerable<ProductAttributeResponse>>> GetsByName([FromQuery] string name = null)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.Name.Contains(name);
            var includes = new[] { "Product" };

            var query = new GetAllProductAttributesQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/values")]
        public async Task<ActionResult<IEnumerable<ProductAttributeResponse>>> GetsByValue([FromQuery] string value = null)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.Value.Contains(value);
            var includes = new[] { "Product" };

            var query = new GetAllProductAttributesQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/productId")]
        public async Task<ActionResult<IEnumerable<ProductAttributeResponse>>> GetsByProductId([FromQuery] int id = 0)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.ProductId == id;
            var includes = new[] { "Product" };

            var query = new GetAllProductAttributesQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<ProductAttributeResponse>> GetById(int id)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.Id == id;
            var query = new GetProductAttributesQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<ProductAttributeResponse>> GetByName(string name)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.Name == name;
            var query = new GetProductAttributesQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/value")]
        public async Task<ActionResult<ProductAttributeResponse>> GetByValue(string value)
        {
            Expression<Func<ProductAttribute, bool>> predicate = x => x.Value == value;
            var query = new GetProductAttributesQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateProductAttributeCommand entity)
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

        [HttpPut("put")]
        public async Task<IActionResult> Put(UpdateProductAttributeCommand entity)
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
        public async Task<IActionResult> Delete(DeleteProductAttributeCommand entity)
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
