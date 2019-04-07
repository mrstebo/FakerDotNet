using System;
using System.Linq;
using System.Numerics;
using FakerDotNet.Data;
using FakerDotNet.Extensions;

namespace FakerDotNet.Fakers
{
    public interface IBankFaker
    {
        string AccountNumber(int digits = 10);
        string Iban(string countryCode = "GB");
        string Name();
        string RoutingNumber();
        string RoutingNumberWithFormat();
        string SwiftBic();
    }

    internal class BankFaker : IBankFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public BankFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string AccountNumber(int digits = 10)
        {
            return string.Join("", Enumerable.Range(0, digits).Select(_ => _fakerContainer.Number.Digit()));
        }

        public string Iban(string countryCode = "GB")
        {
            var key = (countryCode ?? "").ToLowerInvariant();

            if (countryCode == null || !BankData.IbanDetails.ContainsKey(key))
            {
                throw new ArgumentException($"Could not find iban details for {countryCode}");
            }

            var (_, pattern) = BankData.IbanDetails[key];
            var account = _fakerContainer.Regexify.Parse(pattern);
            var checksum = IbanChecksum(countryCode, account);

            return $"{countryCode.ToUpperInvariant()}{checksum}{account}";
        }

        public string Name()
        {
            return _fakerContainer.Random.Element(BankData.Names);
        }

        public string RoutingNumber()
        {
            throw new NotImplementedException();
        }

        public string RoutingNumberWithFormat()
        {
            throw new NotImplementedException();
        }

        public string SwiftBic()
        {
            throw new NotImplementedException();
        }

        private static string IbanChecksum(string countryCode, string account)
        {
            var accountToNumberValues = $"{account}{countryCode}00"
                .ToUpperInvariant()
                .Characters()
                .Select(c => char.IsLetter(c, 0) ? char.Parse(c) - 55 : int.Parse(c))
                .ToArray();
            var accountToNumber = BigInteger.Parse(string.Join("", accountToNumberValues));
            var checksum = 98 - (accountToNumber % 97);
            var result = checksum.ToString().PadLeft(2, '0');
            return result;
        }
    }
}
