using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CompassFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _compassFaker = new CompassFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private ICompassFaker _compassFaker;

        [Test]
        public void Direction_returns_a_direction()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.Directions))
                .Returns("{Ordinal}");
            A.CallTo(() => _fakerContainer.Compass.Ordinal())
                .Returns("southeast");

            Assert.AreEqual("southeast", _compassFaker.Direction());
        }

        [Test]
        public void Cardinal_returns_a_cardinal()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.CardinalWords))
                .Returns("north");

            Assert.AreEqual("north", _compassFaker.Cardinal());
        }

        [Test]
        public void Ordinal_returns_an_ordinal()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.OrdinalWords))
                .Returns("northwest");

            Assert.AreEqual("northwest", _compassFaker.Ordinal());
        }

        [Test]
        public void HalfWind_returns_a_half_wind()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.HalfWindWords))
                .Returns("north-northwest");

            Assert.AreEqual("north-northwest", _compassFaker.HalfWind());
        }

        [Test]
        public void QuarterWind_returns_a_quarter_wind()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.QuarterWindWords))
                .Returns("north by west");

            Assert.AreEqual("north by west", _compassFaker.QuarterWind());
        }

        [Test]
        public void Abbreviation_returns_an_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.Abbreviations))
                .Returns("{QuarterWindAbbreviation}");
            A.CallTo(() => _fakerContainer.Compass.QuarterWindAbbreviation())
                .Returns("NEbN");

            Assert.AreEqual("NEbN", _compassFaker.Abbreviation());
        }

        [Test]
        public void CardinalAbbreviation_returns_a_cardinal_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.CardinalAbbreviations))
                .Returns("N");

            Assert.AreEqual("N", _compassFaker.CardinalAbbreviation());
        }

        [Test]
        public void OrdinalAbbreviation_returns_an_ordinal_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.OrdinalAbbreviations))
                .Returns("SW");

            Assert.AreEqual("SW", _compassFaker.OrdinalAbbreviation());
        }

        [Test]
        public void HalfWindAbbreviation_returns_a_half_wind_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.HalfWindAbbreviations))
                .Returns("NNE");

            Assert.AreEqual("NNE", _compassFaker.HalfWindAbbreviation());
        }

        [Test]
        public void QuarterWindAbbreviation_returns_a_quarter_wind_abbreviation()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.QuarterWindAbbreviations))
                .Returns("SWbS");

            Assert.AreEqual("SWbS", _compassFaker.QuarterWindAbbreviation());
        }

        [Test]
        public void Azimuth_returns_an_azimuth()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.Azimuths))
                .Returns("{QuarterWindAzimuth}");
            A.CallTo(() => _fakerContainer.Compass.QuarterWindAzimuth())
                .Returns("168.75");

            Assert.AreEqual("168.75", _compassFaker.Azimuth());
        }

        [Test]
        public void CardinalAzimuth_returns_a_cardinal_azimuth()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.CardinalAzimuths))
                .Returns("90");

            Assert.AreEqual("90", _compassFaker.CardinalAzimuth());
        }

        [Test]
        public void OrdinalAzimuth_returns_an_ordinal_azimuth()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.OrdinalAzimuths))
                .Returns("135");

            Assert.AreEqual("135", _compassFaker.OrdinalAzimuth());
        }

        [Test]
        public void HalfWindAzimuth_returns_a_half_wind_azimuth()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.HalfWindAzimuths))
                .Returns("292.5");

            Assert.AreEqual("292.5", _compassFaker.HalfWindAzimuth());
        }

        [Test]
        public void QuarterWindAzimuth_returns_a_quarter_wind_azimuth()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CompassData.QuarterWindAzimuths))
                .Returns("56.25");

            Assert.AreEqual("56.25", _compassFaker.QuarterWindAzimuth());
        }
    }
}
