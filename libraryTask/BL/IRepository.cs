using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryTask.BL
{
    interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(params object[] Id);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
    }
}
