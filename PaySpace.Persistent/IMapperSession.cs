using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Persistent
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(PostalCode entity);
        Task Delete(PostalCode entity);

        IQueryable<PostalCode> PostalCodes { get; }
    }
}
