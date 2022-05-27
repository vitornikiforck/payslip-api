using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payslip.Api.Controllers.Common;
using Payslip.Api.Controllers.Paymentslips.ViewModels;
using Payslip.Api.Exceptions;
using Payslip.Application.Features.Paymentslips.Queries;
using Payslip.Domain.Features.Paymentslips;

namespace Payslip.Api.Controllers.Paymentslips
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentslipsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentslipsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gera o extrato de contracheque através do identificador de um funcionário.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     GET /api/Paymentslips/b2dd8648-1ca5-4457-a9e3-aaf2d027339f
        ///     
        /// </remarks>
        /// <returns>Extrato de contracheque do funcionário</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaymentslipDetailViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        public async Task<IActionResult> GetByIdAsync(Guid employeeId)
        {
            var query = new PaymentslipGenerateQuery { EmployeeId = employeeId };

            return HandleQuery<Paymentslip, PaymentslipDetailViewModel>(await _mediator.Send(query));
        }
    }
}
