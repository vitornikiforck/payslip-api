using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payslip.Api.Controllers.Common;
using Payslip.Api.Controllers.Employees.ViewModels;
using Payslip.Api.Exceptions;
using Payslip.Application.Features.Employees.Commands;
using Payslip.Application.Features.Employees.Queries;
using Payslip.Domain.Features.Employees;

namespace Payslip.Api.Controllers.Employees
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca um determinado funcionário pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     GET /api/Employees/b2dd8648-1ca5-4457-a9e3-aaf2d027339f
        ///     
        /// </remarks>
        /// <returns>Retorna um funcionário</returns>
        [HttpGet]
        [ProducesResponseType(typeof(EmployeeDetailViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        public async Task<IActionResult> GetByIdAsync(Guid employeeId)
        {
            var query = new EmployeeGetQuery { EmployeeId = employeeId };

            return HandleQuery<Employee, EmployeeDetailViewModel>(await _mediator.Send(query));
        }

        /// <summary>
        /// Registra um novo funcionário.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/Employees
        ///     
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        public async Task<IActionResult> PostAsync([FromBody] EmployeeRegisterCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
    }
}