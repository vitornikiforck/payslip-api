namespace Payslip.Api.Exceptions
{
    public class ValidationFailure
    {

        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public object AttemptedValue { get; set; }

        public object CustomState { get; set; }

        public string ErrorCode { get; set; }

        public object[] FormattedMessageArguments { get; set; }

        public Dictionary<string, object> FormattedMessagePlaceholderValues { get; set; }

        public string ResourceName { get; set; }

    }
}
