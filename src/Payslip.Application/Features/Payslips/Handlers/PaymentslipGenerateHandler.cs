using AutoMapper;
using MediatR;
using Payslip.Application.Features.Paymentslips.Queries;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;
using Payslip.Domain.Features.Paymentslips;

namespace Payslip.Application.Features.Payslips.Handlers
{
    public record PaymentslipGenerateHandler : IRequestHandler<PaymentslipGenerateQuery, Result<Exception, Paymentslip>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public PaymentslipGenerateHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result<Exception, Paymentslip>> Handle(PaymentslipGenerateQuery request, CancellationToken cancellationToken)
        {
            var employeeCallback = await _employeeRepository.GetById(request.EmployeeId);
            
            if (employeeCallback.IsFailure)
                return employeeCallback.Failure;

            var employee = employeeCallback.Success;

            var paymentSlip = new Paymentslip(employee);

            return paymentSlip;
        }
    }
}