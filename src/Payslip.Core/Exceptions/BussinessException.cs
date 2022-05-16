namespace Payslip.Core.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException(StatusCodes statusCode, string message) : base(message)
        {
            StatusCodes = statusCode;
        }

        public StatusCodes StatusCodes { get; }
    }
}
