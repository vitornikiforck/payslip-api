using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Payslip.Domain.Features.Launches;
using System.ComponentModel.DataAnnotations;

namespace Payslip.Api.Controllers.Launches
{
    /// <summary>
    /// 
    /// Representa o resultado da criação dos lançamentos de um contracheque
    /// 
    /// É usado quando se precisa dos dados sobre de lançamentos do contracheque
    ///  
    /// </summary>
    public class LauncheDetailViewModel
    {
        [EnumDataType(typeof(LaunchType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public LaunchType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}