using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRLeaveManagement.Presistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType
            {
                Id = 1,
                Name = "Annual Leave",
                DefaultDays = 10,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            }
            );


        builder.Property(p => p.Name).
            IsRequired().
            HasMaxLength(70);
    }
}
