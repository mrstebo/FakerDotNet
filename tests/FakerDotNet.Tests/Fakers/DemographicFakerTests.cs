using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class DemographicFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _demographicFaker = new DemographicFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IDemographicFaker _demographicFaker;

        [Test]
        public void Race_returns_a_race()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DemographicData.Races))
                .Returns("Native Hawaiian or Other Pacific Islander");

            Assert.AreEqual("Native Hawaiian or Other Pacific Islander", _demographicFaker.Race());
        }

        [Test]
        public void EducationalAttainment_returns_an_educational_attainment()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DemographicData.EducationalAttainments))
                .Returns("GED or alternative credential");

            Assert.AreEqual("GED or alternative credential", _demographicFaker.EducationalAttainment());
        }

        [Test]
        public void Demonym_returns_a_demonym()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DemographicData.Demonyms))
                .Returns("Panamanian");

            Assert.AreEqual("Panamanian", _demographicFaker.Demonym());
        }

        [Test]
        public void MaritalStatus_returns_a_marital_status()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DemographicData.MaritalStatuses))
                .Returns("Widowed");

            Assert.AreEqual("Widowed", _demographicFaker.MaritalStatus());
        }

        [Test]
        public void Sex_returns_a_sex()
        {
            A.CallTo(() => _fakerContainer.Random.Element(DemographicData.Sexes))
                .Returns("Female");

            Assert.AreEqual("Female", _demographicFaker.Sex());
        }

        [Test]
        public void Height_returns_a_height_in_metric_units()
        {
            A.CallTo(() => _fakerContainer.Number.Between(1.45, 2.13))
                .Returns(1.613243);

            Assert.AreEqual("1.61", _demographicFaker.Height());
        }

        [Test]
        public void Height_returns_a_height_in_imperial_units_when_specified()
        {
            A.CallTo(() => _fakerContainer.Number.Between(57, 86))
                .Returns(74);

            Assert.AreEqual("6 ft, 2 in", _demographicFaker.Height(UnitType.Imperial));
        }
    }
}
