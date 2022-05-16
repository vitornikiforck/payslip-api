namespace Payslip.Infra.Validations
{
	public static class DocumentValidator
	{
		public static bool ValidateCpf(string cpf)
		{
			int[] firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string auxCpf;
			string digit;
			int sum, remainder;

			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)
				return false;

			auxCpf = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(auxCpf[i].ToString()) * firstMultiplier[i];
			remainder = sum % 11;

			if (remainder < 2)
				remainder = 0;
			else
				remainder = 11 - remainder;

			digit = remainder.ToString();
			auxCpf = auxCpf + digit;
			sum = 0;

			for (int i = 0; i < 10; i++)
				sum += int.Parse(auxCpf[i].ToString()) * secondMultiplier[i];

			remainder = sum % 11;

			if (remainder < 2)
				remainder = 0;
			else
				remainder = 11 - remainder;

			digit = digit + remainder.ToString();

			return cpf.EndsWith(digit);
		}
	}
}
