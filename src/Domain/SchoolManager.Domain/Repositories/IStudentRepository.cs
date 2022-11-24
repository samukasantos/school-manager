
using SchoolManager.Core.Data;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Domain.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<bool> AddAsync(Student student);
        Task<ICollection<Student>> GetAllAsync();
        Task<bool> UpdateAsync(Student student);
        Task<Student> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
