
using SchoolManager.Core.Data;
using SchoolManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SchoolManager.Domain.Repositories
{
    public interface IEnrolmentRepository : IRepository<Enrolment>
    {
        Task<bool> AddAsync(Enrolment enrolment);
        Task<ICollection<Enrolment>> GetAllAsync();
        Task<Enrolment> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
