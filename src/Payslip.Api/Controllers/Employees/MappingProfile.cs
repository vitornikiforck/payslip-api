using AutoMapper;
using Payslip.Api.Controllers.Employees.ViewModels;
using Payslip.Domain.Features.Employees;

namespace Payslip.Api.Controllers.Employees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDetailViewModel>();
        }
    }
}
