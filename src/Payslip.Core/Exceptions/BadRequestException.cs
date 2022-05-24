namespace Payslip.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(StatusCodes statusCode, string message) : base(message)
        {
            StatusCodes = statusCode;
        }

        public StatusCodes StatusCodes { get; }
    }
}
