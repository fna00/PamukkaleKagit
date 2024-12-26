using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.Category;
using PamukkaleKagit.Application.Commands.SubCategories;
using PamukkaleKagit.Application.Queries.Categories;
using PamukkaleKagit.Application.Queries.SubCategories;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;
using PamukkaleKagit.Models.ResponseModels.Categories;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Queries
        [HttpGet("gets/subcategory")] 
        public async Task<ActionResult<IEnumerable<SubCategoryResponse>>> GetsByName([FromQuery] string name = null)
        {
            Expression<Func<SubCategory, bool>> predicate = x => string.IsNullOrEmpty(name) || x.Name.Contains(name);
            var includes = new[] { "Products" , "Category" };

            var query = new GetAllSubCategoryQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }
        [HttpGet("gets/categoryId")]
        public async Task<ActionResult<IEnumerable<SubCategoryResponse>>> GetsByCategoryId([FromQuery] int id = 0)
        {
            Expression<Func<SubCategory, bool>> predicate = x => x.CategoryId == id;
            var includes = new[] { "Products", "Category" };

            var query = new GetAllSubCategoryQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<SubCategoryResponse>> GetById(int id)
        {
            Expression<Func<SubCategory, bool>> predicate = x => x.Id == id;
            var query = new GetSubCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<SubCategoryResponse>> GetByName(string name)
        {
            Expression<Func<SubCategory, bool>> predicate = x => x.Name == name;
            var query = new GetSubCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/image")]
        public async Task<ActionResult<SubCategoryResponse>> GetByImage(string image)
        {
            Expression<Func<SubCategory, bool>> predicate = x => x.Image == image;
            var query = new GetSubCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/categoryId")]
        public async Task<ActionResult<SubCategoryResponse>> GetByCategoryId(int id = 0)
        {
            Expression<Func<SubCategory, bool>> predicate = x => x.CategoryId == id;
            var query = new GetSubCategoryQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //Commands
        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateSubCategoryCommand entity)
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
        public async Task<IActionResult> Put(UpdateSubCategoryCommand entity)
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
        public async Task<IActionResult> Delete(DeleteSubCategoryCommand entity)
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