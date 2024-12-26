using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.ProductTypes;
using PamukkaleKagit.Application.Queries.ProductTypes;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.ProductTypes;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gets/value")]
        public async Task<ActionResult<IEnumerable<ProductTypeResponse>>> GetsByValue([FromQuery] string value = null)
        {
            Expression<Func<ProductType, bool>> predicate = x => x.Value.Contains(value);
            var includes = new[] { "Products", "Type" };

            var query = new GetAllProductTypeQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/typeId")]
        public async Task<ActionResult<IEnumerable<ProductTypeResponse>>> GetsByTypeId([FromQuery] int id = 0)
        {
            Expression<Func<ProductType, bool>> predicate = x => x.TypeId == id;
            var includes = new[] { "Products", "Type" };

            var query = new GetAllProductTypeQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<ProductTypeResponse>> GetById(int id)
        {
            Expression<Func<ProductType, bool>> predicate = x => x.Id == id;
            var query = new GetProductTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/value")]
        public async Task<ActionResult<ProductTypeResponse>> GetByName(string value)
        {
            Expression<Func<ProductType, bool>> predicate = x => x.Value == value;
            var query = new GetProductTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/text")]
        public async Task<ActionResult<ProductTypeResponse>> GetByText(string text)
        {
            Expression<Func<ProductType, bool>> predicate = x => x.Text == text;
            var query = new GetProductTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateProductTypeCommand  entity)
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
        public async Task<IActionResult> Put(UpdateProductTypeCommand entity)
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
        public async Task<IActionResult> Delete(DeleteProductTypeCommand entity)
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
