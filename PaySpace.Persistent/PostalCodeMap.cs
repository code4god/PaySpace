using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.Persistent
{
    public class PostalCodeMap : ClassMapping<PostalCode>
    {
        public PostalCodeMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });

            Property(b => b.Code, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("Code");
                x.NotNullable(true);
            });           

            Table("PostalCode");
        }
    }
}
