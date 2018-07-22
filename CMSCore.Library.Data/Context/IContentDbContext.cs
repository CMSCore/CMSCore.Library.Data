using System;
using System.Collections.Generic;
using System.Text;

namespace CMSCore.Library.Data.Context
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IContentDbContext
    {
        IQueryable<TEntity> Set<TEntity>() where TEntity : class;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
