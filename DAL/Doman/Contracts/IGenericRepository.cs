using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task <TEntity?> Find(Guid id);
        Task insert(TEntity entity);
        void Delete(TEntity id);
        void Update(TEntity entity);
    }
}
