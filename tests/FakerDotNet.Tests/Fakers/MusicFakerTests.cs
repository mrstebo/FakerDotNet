using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class MusicFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _musicFaker = new MusicFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IMusicFaker _musicFaker;

        [Test]
        public void Key_returns_a_key()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Keys))
                .Returns("C");
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.KeyVariants))
                .Returns("");

            Assert.AreEqual("C", _musicFaker.Key());
        }

        [Test]
        public void Key_returns_a_key_with_key_variant()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Keys))
                .Returns("C");
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.KeyVariants))
                .Returns("#");

            Assert.AreEqual("C#", _musicFaker.Key());
        }

        [Test]
        public void Chord_returns_a_chord()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Keys))
                .Returns("A");
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.ChordTypes))
                .Returns("");

            Assert.AreEqual("A", _musicFaker.Chord());
        }

        [Test]
        public void Chord_returns_a_chord_with_a_chord_type()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Keys))
                .Returns("A");
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.ChordTypes))
                .Returns("maj7");

            Assert.AreEqual("Amaj7", _musicFaker.Chord());
        }

        [Test]
        public void Instrument_returns_an_instrument()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Instruments))
                .Returns("Ukelele");

            Assert.AreEqual("Ukelele", _musicFaker.Instrument());
        }

        [Test]
        public void Band_returns_a_band()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Bands))
                .Returns("The Beatles");

            Assert.AreEqual("The Beatles", _musicFaker.Band());
        }

        [Test]
        public void Album_returns_an_album()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Albums))
                .Returns("Sgt. Pepper's Lonely Hearts Club");

            Assert.AreEqual("Sgt. Pepper's Lonely Hearts Club", _musicFaker.Album());
        }

        [Test]
        public void Genre_returns_a_genre()
        {
            A.CallTo(() => _fakerContainer.Random.Element(MusicData.Genres))
                .Returns("Rock");

            Assert.AreEqual("Rock", _musicFaker.Genre());
        }
    }
}
