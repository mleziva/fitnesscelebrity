using FitnessCelebrity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Repositories
{
    public interface IBaseRepository<TEntity>
 where TEntity : BaseModel
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(long id);

        Task<TEntity> Create(TEntity entity);

        Task Update(long id, TEntity entity);

        Task Delete(long id);

        IQueryable<T> GetSet<T>() where T : BaseModel;
    }
}
