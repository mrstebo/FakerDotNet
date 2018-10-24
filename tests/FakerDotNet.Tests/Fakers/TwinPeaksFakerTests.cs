using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class TwinPeaksFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _twinPeaksFaker = new TwinPeaksFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private TwinPeaksFaker _twinPeaksFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TwinPeaksData.Characters))
                .Returns("Annie Blackburn");

            Assert.AreEqual("Annie Blackburn", _twinPeaksFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TwinPeaksData.Locations))
                .Returns("Black Lake");

            Assert.AreEqual("Black Lake", _twinPeaksFaker.Location());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TwinPeaksData.Quotes))
                .Returns("You know, this is — excuse me — a damn fine cup of coffee!");

            Assert.AreEqual("You know, this is — excuse me — a damn fine cup of coffee!", _twinPeaksFaker.Quote());
        }
    }
}
