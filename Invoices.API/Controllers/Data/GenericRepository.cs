
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Invoices.API.Data {

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
                                                where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll(params string[] includes){
            return _context.Set<TEntity>();
        }
 
        public async Task<TEntity> GetById(string id,params string[] includes){
            var qry = _context.Set<TEntity>().AsQueryable();
            return await includes.Aggregate(qry, (current, include) => current.Include(include))
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    
        public async Task Create(TEntity entity){
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    
        public async Task Update(TEntity entity) {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string id) {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}