using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySpace.Persistent.Repository
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DbContext;

        public Repository(DbContext context)
        {
            DbContext = context;
        }

        public void Add(TModel entity)
        {
            DbContext.Set<TModel>().Add(entity);
        }

        public TModel Get(int id)
        {
            return DbContext.Set<TModel>().Find(id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return DbContext.Set<TModel>().ToList();
        }

        public void Remove(TModel entity)
        {
            DbContext.Set<TModel>().Remove(entity);
        }
    }
}
