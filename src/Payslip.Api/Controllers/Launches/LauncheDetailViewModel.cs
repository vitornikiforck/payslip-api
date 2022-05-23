using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Payslip.Domain.Features.Launches;
using System.ComponentModel.DataAnnotations;

namespace Payslip.Api.Controllers.Launches
{
    public class LauncheDetailViewModel
    {
        [EnumDataType(typeof(LaunchType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public LaunchType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}