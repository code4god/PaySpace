using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.Persistent
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
