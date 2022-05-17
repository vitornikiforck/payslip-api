using Payslip.Domain.Features.Launches;

namespace Payslip.Api.Controllers.Launches
{
    public class LauncheDetailViewModel
    {
        public LaunchType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}