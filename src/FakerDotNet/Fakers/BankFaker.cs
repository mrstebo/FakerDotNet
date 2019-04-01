using System;

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
            throw new NotImplementedException();
        }

        public string Iban(string countryCode = "GB")
        {
            throw new NotImplementedException();
        }

        public string Name()
        {
            throw new NotImplementedException();
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
    }
}
