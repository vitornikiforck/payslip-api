using Payslip.Core.Results;

namespace Payslip.Domain.Features.Employees
{
    public interface IEmployeeRepository
    {
        Task<Result<Exception, Employee>> AddAsync(Employee employee);
        Task<Result<Exception, Employee>> GetById(Guid employeeId);
    }
}
