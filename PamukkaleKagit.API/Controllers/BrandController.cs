using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.Brands;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Queries.Brands;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Brands;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gets/name")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetsByName([FromQuery] string name = null)
        {
            Expression<Func<Brand, bool>> predicate = x => x.Name.Contains(name);
            var includes = new[] { "Products" };

            var query = new GetAllBrandQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<BrandResponse>> GetById(int id)
        {
            Expression<Func<Brand, bool>> predicate = x => x.Id == id;
            var query = new GetBrandQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<BrandResponse>> GetByName(string name)
        {
            Expression<Func<Brand, bool>> predicate = x => x.Name == name;
            var query = new GetBrandQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateBrandCommand entity)
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
        public async Task<IActionResult> Put(UpdateBrandCommand entity)
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
        public async Task<IActionResult> Delete(DeleteBrandCommand entity)
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
