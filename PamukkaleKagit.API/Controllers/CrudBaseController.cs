using Microsoft.AspNetCore.Mvc;
using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Repositories;

namespace PamukkaleKagit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudBaseController<T> : ControllerBase, IApiController<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public CrudBaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        //[HttpGet("GetAll")]
        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    var entities = await _repository.GetAllAsync();
        //    return entities;
        //}

        //[HttpGet("GetById")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var entity = await _repository.GetByIdAsync(id);
        //    if (entity == null)
        //    {
        //        return NotFound();  // Return 404 if not found
        //    }
        //    return Ok(entity);  // Return 200 with the entity
        //}

        //[HttpPost("Post")]
        //public async Task<IActionResult> Post(T entity)
        //{
        //    if (entity == null)
        //    {
        //        return BadRequest();  // Return 400 if the entity is null
        //    }
        //    await _repository.CreateAsync(entity);
        //    return Ok(entity);  // Return 200 with the created entity
        //}

        //[HttpPut("Put")]
        //public async Task<IActionResult> Put(int id, T entity)
        //{
        //    if (entity == null)
        //    {
        //        return BadRequest();  // Return 400 if the entity is null
        //    }
        //    var existingEntity = await _repository.GetByIdAsync(id);
        //    if (existingEntity == null)
        //    {
        //        return NotFound();  // Return 404 if the entity does not exist
        //    }

        //    await _repository.UpdateAsync( id, entity);
        //    return Ok(entity);  // Return 200 with the updated entity
        //}

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(T entity)
        //{
        //    if (entity == null)
        //    {
        //        return NotFound();  // Return 404 if not found
        //    }

        //    await _repository.DeleteAsync(entity);
        //    return Ok();  // Return 200 on successful deletion
        //}

        Task<IEnumerable<T>> IApiController<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T> IApiController<T>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<T> IApiController<T>.Post(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IApiController<T>.Put(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IApiController<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}