using System;

namespace FakerDotNet.Fakers
{
    public interface IStarWarsFaker
    {
        string CallSquadron();
        string CallSign();
        string CallNumber();
        string Character();
        string Droid();
        string Planet();
        string Quote(string character = "");
        string Specie();
        string Vehicle();
        string WookieeSentence();
    }

    internal class StarWarsFaker : IStarWarsFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public StarWarsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string CallSquadron()
        {
            throw new NotImplementedException();
        }

        public string CallSign()
        {
            throw new NotImplementedException();
        }

        public string CallNumber()
        {
            throw new NotImplementedException();
        }

        public string Character()
        {
            throw new NotImplementedException();
        }

        public string Droid()
        {
            throw new NotImplementedException();
        }

        public string Planet()
        {
            throw new NotImplementedException();
        }

        public string Quote(string character = "")
        {
            throw new NotImplementedException();
        }

        public string Specie()
        {
            throw new NotImplementedException();
        }

        public string Vehicle()
        {
            throw new NotImplementedException();
        }

        public string WookieeSentence()
        {
            throw new NotImplementedException();
        }
    }
}
