using MediatR;
using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Application.Commands.Types;
using PamukkaleKagit.Application.Queries.Types;
using PamukkaleKagit.Models.ResponseModels.Types;
using System.Linq.Expressions;
using Type = PamukkaleKagit.Domain.Entities.Type;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMediator _mediator = null!;

        public TypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Queries
        [HttpGet("gets/name")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetsByName([FromQuery] string name = null)
        {
            Expression<Func<Type, bool>> predicate = x => x.Name.Contains(name);
            var includes = new[] { "ProductTypes" };

            var query = new GetAllTypeQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("gets/symbol")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetsBySymbol([FromQuery] string symbol = null)
        {
            Expression<Func<Type, bool>> predicate = x => x.Symbol.Contains(symbol);
            var includes = new[] { "ProductTypes" };

            var query = new GetAllTypeQuery(predicate, includes);
            var entities = await _mediator.Send(query);
            return Ok(entities);
        }

        [HttpGet("get/id")]
        public async Task<ActionResult<TypeResponse>> GetById(int id)
        {
            Expression<Func<Type, bool>> predicate = x => x.Id == id;
            var query = new GetTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/name")]
        public async Task<ActionResult<TypeResponse>> GetByName(string name)
        {
            Expression<Func<Type, bool>> predicate = x => x.Name == name;
            var query = new GetTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("get/symbol")]
        public async Task<ActionResult<TypeResponse>> GetBySmybol(string symbol)
        {
            Expression<Func<Type, bool>> predicate = x => x.Symbol == symbol;
            var query = new GetTypeQuery(predicate);
            var entity = await _mediator.Send(query);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //Commands
        [HttpPost("post")]
        public async Task<IActionResult> Post(CreateTypeCommand entity)
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
        public async Task<IActionResult> Put(UpdateTypeCommand entity)
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
        public async Task<IActionResult> Delete(DeleteTypeCommand entity)
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
