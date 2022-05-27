using FluentValidation;
using MediatR;
using Payslip.Application.Behaviours;
using Payslip.Core.Results;

namespace Payslip.Api.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<Exception,TResponse>>
            where TRequest : IRequestWithResult<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Result<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<Exception, TResponse>> next)
        {
            if (_validators.Any())
            {
                var failures = _validators
                    .Select(v => v.Validate(request))
                    .SelectMany(result => result.Errors)
                    .Where(error => error != null)
                    .ToList();

                if (failures.Any())
                {
                    return new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
