using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Payslip.Api.Exceptions;

namespace Payslip.Api.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Método invocado quando ocorre uma exceção no controller
        /// </summary>
        /// <param name="context">É o contexto atual da requisição</param>
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(ExceptionPayload.New(context.Exception));
        }
    }
}
