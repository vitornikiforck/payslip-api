using FluentValidation;
using Payslip.Application.Behaviours;
using Payslip.Infra.Validations;

namespace Payslip.Application.Features.Employees.Commands
{
    public class EmployeeRegisterCommand : IRequestWithResult<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Department { get; set; }
        public decimal GrossSalary { get; set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool TransportantionVoucher { get; set; }
    }

    public class EmployeeRegisterCommandValidator : AbstractValidator<EmployeeRegisterCommand>
    {
        public EmployeeRegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome deve ser informado.")
                .MaximumLength(50)
                .WithMessage("Nome não deve ultrapassar 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sobrenome deve ser informado.")
                .MaximumLength(100)
                .WithMessage("Sobrenome não deve ultrapassar 100 caracteres.");

            RuleFor(x => x.Document)
                .Must(x => DocumentValidator.ValidateCpf(x))
                .WithMessage("CPF está inválido.");

            RuleFor(x => x.GrossSalary)
                .ScalePrecision(2, 6)
                .WithMessage("Informe um salário válido.");

            RuleFor(x => x.Department)
            .NotNull()
            .NotEmpty()
            .WithMessage("Sobrenome deve ser informado.")
            .MaximumLength(100)
            .WithMessage("Sobrenome não deve ultrapassar 100 caracteres.");
        }
    }
}
