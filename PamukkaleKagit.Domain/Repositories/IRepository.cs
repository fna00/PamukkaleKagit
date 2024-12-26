using PamukkaleKagit.Domain.Entities;
using PamukkaleKagit.Domain.Response.PaginatedList;
using System.Linq.Expressions;

namespace PamukkaleKagit.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //tüm x'i getirir
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null, 
            params string[] includes);

        Task<IEnumerable<T>> GetsAsync(
            Expression<Func<T, bool>>? predicate = null,
            string[]? includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        //Pagination
        Task<PagedResponse<T>> GetPagedResponseAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? predicate = null,
            params string[] includes);

        // ID'ye göre bir x getirir
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        // Yeni bir x ekler
        Task<T> CreateAsync(T entity);

        // Varolan bir x'i günceller
        Task<T> UpdateAsync(int id, T entity);

        // Bir x'i siler
        Task<bool> DeleteAsync(T entity);
    }
}
