using FluentValidation;
using Payslip.Core.Exceptions;

namespace Payslip.Api.Exceptions
{
    public class ExceptionPayload
    {
        public ExceptionPayload(string error, int errorCode, string message, List<ValidationFailure> failures = null)
        {
            Error = error;
            ErrorCode = errorCode;
            ErrorMessage = message;
            Failures = failures;
        }

        public string Error { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public List<ValidationFailure> Failures { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            string error;
            int errorCode;
            List<ValidationFailure> failures = null;

            if (exception is BussinessException)
            {
                error = (exception as BussinessException).StatusCodes.ToString();
                errorCode = (exception as BussinessException).StatusCodes.GetHashCode();
            }
            else if(exception is ValidationException)
            {
                error = Core.Exceptions.StatusCodes.BadRequest.ToString();
                errorCode = (int)Core.Exceptions.StatusCodes.BadRequest;
                failures = new ValidationFailureMapper().Map((exception as ValidationException).Errors);
            }
            else
            {
                error = Core.Exceptions.StatusCodes.Unhandled.ToString();
                errorCode = Core.Exceptions.StatusCodes.Unhandled.GetHashCode();
            }

            return new ExceptionPayload(error, errorCode, exception.Message, failures);
        }
    }
}