
using SchoolManager.Core.Data;
using SchoolManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SchoolManager.Domain.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<bool> AddAsync(Subject subject);
        Task<ICollection<Subject>> GetAllAsync();
        Task<bool> UpdateAsync(Subject subject);
        Task<Subject> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
