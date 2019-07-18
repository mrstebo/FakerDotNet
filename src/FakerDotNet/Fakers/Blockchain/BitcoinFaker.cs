namespace FakerDotNet.Fakers.Blockchain
{
    public interface IBitcoinFaker
    {
        string Address();
        string TestnetAddress();
    }
    
    internal class BitcoinFaker : IBitcoinFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public BitcoinFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Address()
        {
            return "1HUoGjmgChmnxxYhz87YytV4gVjfPaExmh";
        }

        public string TestnetAddress()
        {
            return "msHGunDvoEwmVFXvd2Bub1SNw5RP1YHJaf";
        }
    }
}
