using SchoolManager.Core.Data;
using SchoolManager.Core.DomainObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SchoolManager.Api.Data.Context;

namespace SchoolManager.Api.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IRepository<T>
            where T : IAggregateRoot
    {
        #region Fields

        protected readonly SchoolManagerDbContext context;

        #endregion

        #region Propperties

        public IUnitOfWork UnitOfWork => context;

        #endregion

        #region Constructor

        public BaseRepository(SchoolManagerDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual Task<bool> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ICollection<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        #endregion
    }
}
