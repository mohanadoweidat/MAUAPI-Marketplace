using MAUAPI.Core.IRepositories;
using MAUAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MAUAPI.Core.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        protected ApplicationDbContext _context;
        protected readonly ILogger _logger;
        protected DbSet<T> dbSet; 
        

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();  
        }
        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
          
        }
        public virtual async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
