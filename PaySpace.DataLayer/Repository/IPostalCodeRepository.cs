using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataLayer.Repository
{
    public interface IPostalCodeRepository
    {
        void Add(PostalCode postalCode);
        void Remove(PostalCode postalCode);
        PostalCode Get(int Id);
        IEnumerable<PostalCode> GetAll();
    }
}
