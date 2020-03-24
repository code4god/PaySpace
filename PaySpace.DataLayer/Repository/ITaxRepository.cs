using PaySpace.DataLayer.Model;
using System.Collections.Generic;

namespace PaySpace.DataLayer
{
    public interface ITaxRepository
    {
        void Add(Tax tax);
        void Remove(Tax tax);
        Tax Get(int Id);

        IEnumerable<Tax> GetAll();

    }
}
