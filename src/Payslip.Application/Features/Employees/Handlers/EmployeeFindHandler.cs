using MediatR;
using Payslip.Application.Features.Employees.Queries;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;

namespace Payslip.Application.Features.Employees.Handlers
{
    public record EmployeeFindHandler : IRequestHandler<EmployeeGetQuery, Result<Exception, Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeFindHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<Exception, Employee>> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetById(request.EmployeeId);
        }
    }
}