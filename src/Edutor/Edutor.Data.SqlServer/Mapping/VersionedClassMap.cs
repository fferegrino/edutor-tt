using Edutor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.SqlServer.Mapping
{
    public abstract class VersionedClassMap<T> : FluentNHibernate.Mapping.ClassMap<T> where T : IVersionedEntity
    {
        protected VersionedClassMap()
        {

            //// TODO: Page 78 implement versioning
            //Version(x => x.Version)
            //    .Column("ts")
            //    .CustomSqlType("Rowversion")
            //    .Generated.Always()
            //    .UnsavedValue("null");
        }
    }
}
