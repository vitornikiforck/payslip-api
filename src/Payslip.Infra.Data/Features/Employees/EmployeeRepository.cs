using Microsoft.EntityFrameworkCore;
using Payslip.Core.Exceptions;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;
using Payslip.Infra.Data.Contexts;

namespace Payslip.Infra.Data.Features.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PayslipDbContext _context;

        public EmployeeRepository(PayslipDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="employee">Funcionário para ser cadastrado</param>
        /// <returns>O funcionário que foi cadastrado</returns>
        public async Task<Result<Exception, Employee>> AddAsync(Employee employee)
        {
            var newEmployee = _context.Employees.Add(employee).Entity;

            var saveChangesCallback = await Result.Run(async () => await _context.SaveChangesAsync());
            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return newEmployee;
        }

        /// <summary>
        /// Busca um funcionário por Id.
        /// </summary>
        /// <param name="employeeId">Id do funcionário</param>
        /// <returns>Funcionário cadastrado</returns>
        public async Task<Result<Exception, Employee>> GetById(Guid employeeId)
        {
            var employeeCallback = await Result.Run(() => _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId));

            if (employeeCallback.IsFailure)
                return employeeCallback.Failure;

            if (employeeCallback.Success == null)
                return new NotFoundException();

            return employeeCallback;
        }

        /// <summary>
        /// Atualiza os dados do Funcionário.
        /// </summary>
        /// <param name="employee">funcionário para ser atualizado</param>
        /// <returns>O funcionário que foi atualizado</returns>
        public async Task<Result<Exception, Employee>> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            var saveChangesCallback = await Result.Run(() => _context.SaveChangesAsync());

            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return employee;
        }
    }
}
