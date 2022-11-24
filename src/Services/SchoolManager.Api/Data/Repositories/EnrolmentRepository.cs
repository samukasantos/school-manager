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
    public class EnrolmentRepository : BaseRepository<Enrolment>, IEnrolmentRepository
    {
        #region Constructor

        public EnrolmentRepository(SchoolManagerDbContext context)
            : base(context) { }

        #endregion


        #region Methods

        public override async Task<bool> AddAsync(Enrolment enrolment)
        {
            await context.Enrolments.AddAsync(enrolment);

            return await context.Commit();
        }

        public override async Task<ICollection<Enrolment>> GetAllAsync()
        {
            return await context
                        .Enrolments
                            .Include(p => p.Student)
                            .Include(p => p.Subject)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public override async Task<Enrolment> GetByIdAsync(Guid id)
        {
            return await context
                    .Enrolments
                        .Include(p => p.Student)
                        .Include(p => p.Subject)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(k => k.Id == id);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var enrolment = await GetByIdAsync(id);

            context.Enrolments.Remove(enrolment);

            return await context.Commit();
        }

        #endregion
    }
}
