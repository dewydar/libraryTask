using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace libraryTask.BL
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : System.Data.Entity.DbContext, new()
    {
        TContext context;
        DbSet<TEntity> db;
        public Repository(TContext _context)
        {
            context = _context;
            db = context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            db.Add(entity);
            return context.SaveChanges() > 0 ? entity : null;
        }

        public IQueryable<TEntity> GetAll()
        {
            return db;
        }

        public TEntity GetById(params object[] Id)
        {
            return db.Find(Id);
        }

        public bool Remove(TEntity entity)
        {
            db.Remove(entity);
            return context.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
    }
}