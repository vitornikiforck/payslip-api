using AutoMapper;
using Payslip.Api.Controllers.Paymentslips.ViewModels;
using Payslip.Domain.Features.Paymentslips;

namespace Payslip.Api.Controllers.Paymentslips
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paymentslip, PaymentslipDetailViewModel>()
                .ForMember(dest => dest.TotalDiscountValue, opt => opt.MapFrom(src => src.TotalDiscountValueNegative));
        }
    }
}