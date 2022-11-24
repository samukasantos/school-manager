

using SchoolManager.Core.DomainObjects;
using System;

namespace SchoolManager.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
