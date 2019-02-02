using System;
using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IMusicFaker
    {
        string Key();
        string Chord();
        string Instrument();
        string Band();
        string Album();
        string Genre();
    }

    internal class MusicFaker : IMusicFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public MusicFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Key()
        {
            return string.Join("",
                _fakerContainer.Random.Element(MusicData.Keys),
                _fakerContainer.Random.Element(MusicData.KeyVariants));
        }

        public string Chord()
        {
            return string.Join("",
                _fakerContainer.Random.Element(MusicData.Keys),
                _fakerContainer.Random.Element(MusicData.ChordTypes));
        }

        public string Instrument()
        {
            return _fakerContainer.Random.Element(MusicData.Instruments);
        }

        public string Band()
        {
            return _fakerContainer.Random.Element(MusicData.Bands);
        }

        public string Album()
        {
            return _fakerContainer.Random.Element(MusicData.Albums);
        }

        public string Genre()
        {
            return _fakerContainer.Random.Element(MusicData.Genres);
        }
    }
}
