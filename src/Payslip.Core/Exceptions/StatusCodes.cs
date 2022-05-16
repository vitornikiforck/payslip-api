namespace Payslip.Core.Exceptions
{
    public enum StatusCodes
    {
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        NotAllowed = 405,
        AlreadyExists = 409,
        PreconditionFailed = 412,
        InvalidObject = 422,
        Unhandled = 500,
        ServiceUnavailable = 503
    }
}
