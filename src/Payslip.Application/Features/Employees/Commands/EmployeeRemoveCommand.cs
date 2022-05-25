using FluentValidation;
using Payslip.Application.Behaviours;
using Unit = Payslip.Core.Results.Unit;


namespace Payslip.Application.Features.Employees.Commands
{
    /// <summary>
    ///
    /// Representa o comando (dados necessários) para remover um funcionário da base de dados
    ///
    /// </summary>
    public sealed record EmployeeRemoveCommand : IRequestWithResult<Unit>
    {
        public Guid EmployeeId { get; set; }
    }

    public sealed class EmployeeRemoveCommandValidator : AbstractValidator<EmployeeRemoveCommand>
    {
        public EmployeeRemoveCommandValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o identificador do funcionário.");
        }
    }
}
