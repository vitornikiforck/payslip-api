using FluentValidation;
using MediatR;
using Payslip.Core.Results;
using Payslip.Domain.Features.Paymentslips;

namespace Payslip.Application.Features.Paymentslips.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta por id para a geraçao do contracheque do funcionário
    ///  
    /// </summary>
    public class PaymentslipGenerateQuery : IRequest<Result<Exception, Paymentslip>>
    {
        public Guid EmployeeId { get; set; }
    }

    public class GeneratePayslipQueryValidator : AbstractValidator<PaymentslipGenerateQuery>
    {
        public GeneratePayslipQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o identificador do funcionário.");
        }
    }
}
