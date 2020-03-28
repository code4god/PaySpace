using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataLayer
{
    public class UnitOfWork : IDisposable
    {
        private PaySpaceContext context;
        private TaxRepository _taxRepository;

        public UnitOfWork()
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
