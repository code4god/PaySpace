using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataLayer.Repository
{
    public interface ICalculationTypesRepository
    {
        Task AddAsync(CalculationType calculationType);
        Task RemoveAsync(CalculationType calculationType);
        CalculationType Get(int Id);
        CalculationType GetCalculationTypeByPostalCode(int postalCodeId);
        Task<CalculationType> GetAsync(CalculationType calculationType);

        IEnumerable<CalculationType> GetAll();
    }
}
