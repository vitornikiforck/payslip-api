using MediatR;
using Payslip.Application.Features.Employees.Commands;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;
using Unit = Payslip.Core.Results.Unit;

namespace Payslip.Application.Features.Employees.Handlers
{
    public class EmployeeRemoveHandler : IRequestHandler<EmployeeRemoveCommand, Result<Exception, Unit>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeRemoveHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<Exception, Unit>> Handle(EmployeeRemoveCommand request, CancellationToken cancellationToken)
        {
            var findEmployeeCallback = await _employeeRepository.GetById(request.EmployeeId);
            if (findEmployeeCallback.IsFailure)
                return findEmployeeCallback.Failure;

            findEmployeeCallback.Success.SetAsRemoved();

            var updateGenreCallback = await _employeeRepository.UpdateAsync(findEmployeeCallback.Success);
            if (updateGenreCallback.IsFailure)
                return updateGenreCallback.Failure;

            return Unit.Successful;
        }
    }
}
