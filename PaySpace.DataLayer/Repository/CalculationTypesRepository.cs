using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataLayer.Repository
{
    public class CalculationTypesRepository : ICalculationTypesRepository
    {
        private readonly PaySpaceContext _context;
        public CalculationTypesRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }

        public Task AddAsync(CalculationType calculationType)
        {
            _context.CalculationTypes.Add(calculationType);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public CalculationType Get(int Id)
        {
            return _context.CalculationTypes.Where(c=> c.Id == Id).SingleOrDefault();
        }

        public async Task<CalculationType> GetAsync(CalculationType calculationType)
        {
            return await _context.CalculationTypes.FindAsync(calculationType);
        }

        public IEnumerable<CalculationType> GetAll()
        {
            return _context.CalculationTypes.ToList();
        }

        public Task RemoveAsync(CalculationType calculationType)
        {
            _context.Remove(calculationType);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public CalculationType GetCalculationTypeByPostalCode(int postalCodeId)
        {
            return _context.CalculationTypes.Where(c => c.PostalCode.Id == postalCodeId).SingleOrDefault();
        }
    }
}
