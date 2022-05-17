using FluentValidation;
using MediatR;
using Payslip.Application.Behaviours;
using Payslip.Core.Results;

namespace Payslip.Api.Behaviours
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<Exception, TResponse>>
            where TRequest : IRequestWithResult<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<Result<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<Exception, TResponse>> next)
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

            return await next();
        }
    }
}
