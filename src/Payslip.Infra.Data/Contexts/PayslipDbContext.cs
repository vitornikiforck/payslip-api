using Microsoft.EntityFrameworkCore;
using Payslip.Domain.Features.Employees;
using Payslip.Infra.Data.Features.Employees;

namespace Payslip.Infra.Data.Contexts
{
    public class PayslipDbContext : DbContext
    {
        public PayslipDbContext(DbContextOptions<PayslipDbContext> options) : base(options)
        {
        }

        protected PayslipDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">Construtor de modelos do EF</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());

            modelBuilder.HasDefaultSchema("payslip");

            //OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
