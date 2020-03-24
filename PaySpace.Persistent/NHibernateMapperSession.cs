using NHibernate;
using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Persistent
{
    public class NHibernateMapperSession : IMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateMapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<PostalCode> PostalCodes => _session.Query<PostalCode>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(PostalCode entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(PostalCode entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
