using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataLayer.Repository
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly PaySpaceContext _context;
        public PostalCodeRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }
        public Task AddAsync(PostalCode postalCode)
        {
            _context.PostalCodes.Add(postalCode);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<PostalCode> Get(PostalCode postalCode)
        {
           return await _context.PostalCodes.FindAsync(postalCode);
        }

        public PostalCode Get(int Id)
        {
            return _context.PostalCodes.Where(x => x.Id == Id).SingleOrDefault();
        }

        public IEnumerable<PostalCode> GetAll()
        {
            return _context.PostalCodes.ToList();
        }

        public Task RemoveAsync(PostalCode postalCode)
        {
            _context.PostalCodes.Remove(postalCode);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
