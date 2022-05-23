using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payslip.Domain.Features.Employees;

namespace Payslip.Infra.Data.Features.Employees
{
    internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Department).HasMaxLength(30).IsRequired();
            builder.Property(e => e.GrossSalary).HasPrecision(8, 2).IsRequired();
            builder.Property(e => e.AdmissionDate).IsRequired();
            builder.Property(e => e.HealthPlan).IsRequired();
            builder.Property(e => e.DentalPlan).IsRequired();
            builder.Property(e => e.TransportantionVoucher).IsRequired();
            builder.Property(e => e.UpdateAt).IsRequired();
            builder.Property(e => e.IsRemoved).IsRequired();

            builder.HasQueryFilter(e => !e.IsRemoved);
        }
    }
}
