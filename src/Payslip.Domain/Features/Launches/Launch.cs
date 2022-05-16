namespace Payslip.Domain.Features.Launches
{
    public class Launch
    {
        public LaunchType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}
