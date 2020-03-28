using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataLayer.Repository
{
    public interface IPostalCodeRepository
    {
        void Add(PostalCode postalCode);
        void Remove(PostalCode postalCode);
        PostalCode Get(int Id);
        Task<PostalCode> Get(PostalCode postalCode);

        IEnumerable<PostalCode> GetAll();
    }
}
