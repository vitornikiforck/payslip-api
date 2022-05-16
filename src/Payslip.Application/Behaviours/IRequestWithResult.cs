using MediatR;
using Payslip.Core.Results;

namespace Payslip.Application.Behaviours
{
    public interface IRequestWithResult<TResponse> : IRequest<Result<Exception, TResponse>>
    {
    }
}
