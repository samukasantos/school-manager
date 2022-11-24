using Microsoft.EntityFrameworkCore;
using SchoolManager.Api.Data.Context;
using SchoolManager.Api.Data.Repositories.Base;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Api.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        #region Constructor

        public StudentRepository(SchoolManagerDbContext context)
            : base(context) { }

        #endregion


        #region Methods

        public override async Task<bool> AddAsync(Student student)
        {
            await context.Students.AddAsync(student);

            return await context.Commit();
        }


        public override async Task<bool> UpdateAsync(Student student)
        {
            context.Students.Update(student);

            return await context.Commit();
        }

        public override async Task<ICollection<Student>> GetAllAsync()
        {
            return await context
                        .Students
                        .AsNoTracking()
                        .ToListAsync();
        }

        public override async Task<Student> GetByIdAsync(Guid id)
        {
            return await context.Students
                    .Include(p => p.Enrolments)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var student = await GetByIdAsync(id);

            context.Students.Remove(student);

            return await context.Commit();
        }

        #endregion
    }
}
