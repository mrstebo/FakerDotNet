using FakeItEasy;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class StarWarsFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _starwarsFaker = new StarWarsFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IStarWarsFaker _starwarsFaker;

        [Test]
        public void CallSquadron_returns_returns_a_call_squadron()
        {
            Assert.AreEqual("Green", _starwarsFaker.CallSquadron());
        }

        [Test]
        public void CallSign_returns_a_call_sign()
        {
            Assert.AreEqual("Grey 5", _starwarsFaker.CallSign());
        }

        [Test]
        public void CallNumber_returns_a_call_number()
        {
            Assert.AreEqual("Leader", _starwarsFaker.CallNumber());
        }

        [Test]
        public void Character_returns_a_character()
        {
            Assert.AreEqual("Anakin Skywalker", _starwarsFaker.Character());
        }

        [Test]
        public void Droid_returns_a_droid()
        {
            Assert.AreEqual("C-3PO", _starwarsFaker.Droid());
        }

        [Test]
        public void Planet_returns_a_planet()
        {
            Assert.AreEqual("Tatooine", _starwarsFaker.Planet());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            Assert.AreEqual("Aren’t you a little short for a Stormtrooper?", _starwarsFaker.Quote());
        }

        [Test]
        public void Quote_with_character_name_returns_a_quote()
        {
            Assert.AreEqual("Aren’t you a little short for a Stormtrooper?", _starwarsFaker.Quote("leia_organa"));
        }

        [Test]
        public void Specie_returns_a_specie()
        {
            Assert.AreEqual("Gungan", _starwarsFaker.Specie());
        }

        [Test]
        public void Vehicle_returns_a_vehicle()
        {
            Assert.AreEqual("Sandcrawler", _starwarsFaker.Vehicle());
        }

        [Test]
        public void WookieeSentence_returns_a_wookiee_sentence()
        {
            Assert.AreEqual("Yrroonn ru ooma roo ahuma ur roooarrgh hnn-rowr.", _starwarsFaker.WookieeSentence());
        }
    }
}
