using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.Repositories.Base
{
    public interface IRepository<T> where T : class //todo: T: Entity
    {
        Task<IReadOnlyList<T>> GetAllAsync();        
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();

        //Task AddRangeAsync(IEnumerable<T> entities);
        //Task DeleteRange(IEnumerable<T> entities);
        //Task<int> CountAsync(ISpecification<T> spec);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                string includeString = null,
        //                                bool disableTracking = true);
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                List<Expression<Func<T, object>>> includes = null,
        //                                bool disableTracking = true);
        //Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
    }
}
