using FAT.Core.Extensions;

namespace FAT.Core.DomainObjects
{
    public class Cpf
    {
        public string Number { get; private set; }
        public const int CpfMaxLength = 11;

        //EF Constructor
        protected Cpf() { }

        public Cpf(string number)
        {
            if (!Validate(number)) throw new DomainException("Invalid CPF");
            Number = number;
        }

        public static bool Validate(string cpf)
        {
            var cpfNumbers = cpf.OnlyNumbers(cpf);

            if (!ValidSize(cpfNumbers)) return false;
            return !HasRepeatedDigits(cpfNumbers) && HasValidDigits(cpfNumbers);
        }

        private static bool ValidSize(string valor)
        {
            return valor.Length == CpfMaxLength;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, CpfMaxLength - 2);
            var verifyingDigit = new VerifyingDigit(number)
                .WithMultipliersOf(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.CalculateDigit();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CpfMaxLength - 2, 2);
        }
    }

    public class VerifyingDigit
    {
        private string number;
        private const int module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacements = new Dictionary<int, string>();
        private bool _supplementOfModule = true;

        public VerifyingDigit(string number)
        {
            this.number = number;
        }

        public VerifyingDigit WithMultipliersOf(int firstMultiplier, int lastMultiplier)
        {
            _multipliers.Clear();
            for (var i = firstMultiplier; i <= lastMultiplier; i++)
                _multipliers.Add(i);

            return this;
        }

        public VerifyingDigit Replacing(string substitute, params int[] digits)
        {
            foreach (var i in digits)
            {
                _replacements[i] = substitute;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            number = string.Concat(number, digit);
        }

        public string CalculateDigit()
        {
            return !(number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(number[i]) * _multipliers[m];
                sum += product;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % module);
            var resultado = _supplementOfModule ? module - mod : mod;

            return _replacements.ContainsKey(resultado) ? _replacements[resultado] : resultado.ToString();
        }
    }
}
