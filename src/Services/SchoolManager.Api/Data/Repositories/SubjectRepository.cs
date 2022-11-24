using SchoolManager.Api.Data.Context;
using SchoolManager.Api.Data.Repositories.Base;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace SchoolManager.Api.Data.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        #region Constructor

        public SubjectRepository(SchoolManagerDbContext context)
            : base(context) { }

        #endregion


        #region Methods

        public override async Task<bool> AddAsync(Subject subject)
        {
            await context.Subjects.AddAsync(subject);

            return await context.Commit();
        }


        public override async Task<bool> UpdateAsync(Subject subject)
        {
            context.Subjects.Update(subject);

            return await context.Commit();
        }

        public override async Task<ICollection<Subject>> GetAllAsync()
        {
            return await context
                        .Subjects
                        .AsNoTracking()
                        .ToListAsync();
        }

        public override async Task<Subject> GetByIdAsync(Guid id)
        {
            return await context.Subjects.FindAsync(id);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var subject = await GetByIdAsync(id);

            context.Subjects.Remove(subject);

            return await context.Commit();
        }

        #endregion
    }
}
