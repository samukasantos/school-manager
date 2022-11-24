using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Api.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        #region Methods
        
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name)
                .Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            builder.OwnsOne(x => x.Name)
                .Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsRequired();
        } 

        #endregion
    }
}
