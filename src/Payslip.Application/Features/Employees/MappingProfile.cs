using AutoMapper;
using Payslip.Application.Features.Employees.Commands;
using Payslip.Domain.Features.Employees;

namespace Payslip.Application.Features.Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeRegisterCommand, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AdmissionDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsRemoved, opt => opt.Ignore());
        }
    }
}
