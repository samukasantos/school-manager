using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Data;
using SchoolManager.Core.Mediator;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManager.Api.Data.Context
{
    public class SchoolManagerDbContext : DbContext, IUnitOfWork
    {
        
        #region Properties

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }

        #endregion

        #region Constructor

        public SchoolManagerDbContext(DbContextOptions<SchoolManagerDbContext> options)
           : base(options)
        {
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                   e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(120)");
            }
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolManagerDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;

        }
        #endregion
    }
}
