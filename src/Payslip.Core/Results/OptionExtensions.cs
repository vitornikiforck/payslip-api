namespace Payslip.Core.Results
{
    // Baseado em: https://github.com/hugoestevam/OptimusPrime/tree/master/Server/robot.Domain/Results

    public static class Option
    {
        public static Option<T> Of<T>(T value) => new Option<T>(value, value != null);
    }
}
