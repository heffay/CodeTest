using System.Linq;
using System.Threading.Tasks;

namespace Invoices.API.Data
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(params string[] includes);
 
        Task<TEntity> GetById(string id,params string[] includes);
    
        Task Create(TEntity entity);
    
        Task Update(TEntity entity);
    
        Task Delete(string id);
    }
}