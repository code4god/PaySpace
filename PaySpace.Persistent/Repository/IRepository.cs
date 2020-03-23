using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.Persistent.Repository
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        void Add(TModel entity);
        void Remove(TModel entity);
    }
}
