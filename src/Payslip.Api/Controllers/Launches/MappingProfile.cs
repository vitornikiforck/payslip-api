using AutoMapper;
using Payslip.Domain.Features.Launches;

namespace Payslip.Api.Controllers.Launches
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Launch, LauncheDetailViewModel>();
        }
    }
}
