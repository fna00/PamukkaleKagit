using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gets/category")]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetsByName([FromQuery] string? name)
        {
            Expression<Func<Category, bool>> predicate = x => string.IsNullOrEmpty(name) || x.Name.Contains(name);
            var includes = new[]
            {
                "SubCategories"
            };
            //.OrderBy(e => EF.Property<object>(e, "Name"));

            var query = new GetAllCategoryQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/cat")]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> Gets([FromQuery] string? name, [FromQuery] string? sortBy = "Name")
        {
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = sortBy switch
            {
                "Name" => query => query.OrderBy(c => c.Name),
                _ => query => query.OrderBy(c => c.Name)
            };

            Expression<Func<Category, bool>> predicate = x => string.IsNullOrEmpty(name) || x.Name.Contains(name);
            var includes = new[] { "SubCategories" };

            var query = new GetAllCategoryQuery(predicate, includes, orderBy);
            var entities = await _mediator.Send(query);

            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<CategoryResponse>> GetById(int id)
        {
            Expression<Func<Category, bool>> predicate = x => x.Id == id;
            var query = new GetCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<CategoryResponse>> GetByName(string name)
        {
            Expression<Func<Category, bool>> predicate = category => category.Name == name;
            var query = new GetCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //Commands
        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateCategoryCommand entity)
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
        public async Task<IActionResult> Put(UpdateCategoryCommand entity)
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
        public async Task<IActionResult> Delete(DeleteCategoryCommand entity)
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
