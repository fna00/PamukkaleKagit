using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.CategoriesImages;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.CategoriesImages;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.CategoriesImages;
using System.Linq.Expressions;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryImageController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public CategoryImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gets/name")]
        public async Task<ActionResult<IEnumerable<CategoryImageResponse>>> GetsByName([FromQuery] string name = null)
        {
            Expression<Func<CategoryImage, bool>> predicate = x => x.Name.Contains(name);
            var includes = new[] { "Category" };

            var query = new GetAllCategoryImageQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<CategoryImageResponse>> GetById(int id)
        {
            Expression<Func<CategoryImage, bool>> predicate = x => x.Id == id;
            var query = new GetCategoryImageQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<CategoryImageResponse>> GetByName(string name)
        {
            Expression<Func<CategoryImage, bool>> predicate = x => x.Name == name;
            var query = new GetCategoryImageQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/categoryId")]
        public async Task<ActionResult<CategoryImageResponse>> GetByCategoryId(int id)
        {
            Expression<Func<CategoryImage, bool>> predicate = x => x.CategoryId == id;
            var query = new GetCategoryImageQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateCategoryImageCommand entity)
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
        public async Task<IActionResult> Put(UpdateCategoryImageCommand entity)
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
        public async Task<IActionResult> Delete(DeleteCategoryImageCommand entity)
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