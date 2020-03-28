using PaySpace.DataLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaySpace.DataLayer
{
    public interface ITaxRepository
    {
        Task AddAsync(Tax tax);
        Task RemoveAsync(Tax tax);
        Tax Get(int Id);

        IEnumerable<Tax> GetAll();

    }
}
