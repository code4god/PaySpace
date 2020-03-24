using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySpace.DataLayer.Repository
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly PaySpaceContext _context;
        public PostalCodeRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }
        public void Add(PostalCode postalCode)
        {
            throw new NotImplementedException();
        }

        public PostalCode Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostalCode> GetAll()
        {
            return _context.PostalCodes.ToList();
        }

        public void Remove(PostalCode postalCode)
        {
            throw new NotImplementedException();
        }
    }
}
