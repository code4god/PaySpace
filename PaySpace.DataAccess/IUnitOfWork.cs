using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataAccess
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
