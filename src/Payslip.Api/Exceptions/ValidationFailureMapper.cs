using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Payslip.Api.Exceptions
{
    public class ValidationFailureMapper : Profile
    {
        public ValidationFailureMapper()
        {
            CreateMap<FluentValidation.Results.ValidationFailure, ValidationFailure>();
        }

        public List<ValidationFailure> Map(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
        {
            return failures.AsQueryable().ProjectTo<ValidationFailure>().ToList();
        }
    }
}