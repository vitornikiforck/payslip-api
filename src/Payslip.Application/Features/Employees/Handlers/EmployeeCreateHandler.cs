using AutoMapper;
using MediatR;
using Payslip.Application.Features.Employees.Commands;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;

namespace Payslip.Application.Features.Employees.Handlers
{
    public class EmployeeCreateHandler : IRequestHandler<EmployeeRegisterCommand, Result<Exception, Guid>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeCreateHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Guid>> Handle(EmployeeRegisterCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<EmployeeRegisterCommand, Employee>(request);

            var addEmployeeCallback = await _employeeRepository.AddAsync(employee);

            if (addEmployeeCallback.IsFailure)
                return addEmployeeCallback.Failure;

            return addEmployeeCallback.Success.Id;
        }
    }
}
