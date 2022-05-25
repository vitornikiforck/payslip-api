using FluentValidation;
using MediatR;
using Payslip.Core.Results;
using Payslip.Domain.Features.Employees;

namespace Payslip.Application.Features.Employees.Queries
{
    /// <summary>
    /// 
    /// Representa uma consulta por id de um funcionário na base de dados
    ///  
    /// </summary>
    public class EmployeeGetQuery : IRequest<Result<Exception, Employee>>
    {
        public Guid EmployeeId { get; set; }
    }

    public class EmployeeGetQueryValidator : AbstractValidator<EmployeeGetQuery>
    {
        public EmployeeGetQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o identificador do funcionário.");
        }
    }
}