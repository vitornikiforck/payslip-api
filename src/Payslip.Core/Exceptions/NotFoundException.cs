namespace Payslip.Core.Exceptions
{
    public class NotFoundException : BussinessException
    {
        public NotFoundException() : base(StatusCodes.NotFound, "Registro não encontrado.")
        {

        }
    }
}