using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class SuperheroFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _superheroFaker = new SuperheroFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private SuperheroFaker _superheroFaker;

        [Test]
        public void Power_returns_a_power()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Powers))
                .Returns("Aerokinesis");

            Assert.AreEqual("Aerokinesis", _superheroFaker.Power());
        }

        [Test]
        public void Prefix_returns_a_prefix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Prefixes))
                .Returns("Cyborg");

            Assert.AreEqual("Cyborg", _superheroFaker.Prefix());
        }

        [Test]
        public void Suffix_returns_a_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Suffixes))
                .Returns("Dragon");

            Assert.AreEqual("Dragon", _superheroFaker.Suffix());
        }

        [Test]
        public void Descriptor_returns_a_descriptor()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Descriptors))
                .Returns("Abomination");

            Assert.AreEqual("Abomination", _superheroFaker.Descriptor());
        }

        [Test]
        public void Name_returns_a_name_format_a()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Prefixes))
                .Returns("Cyborg");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Suffixes))
                .Returns("Dragon");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Descriptors))
                .Returns("Abomination");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroFaker.NameFormats))
                .Returns("{0} {1} {2}");

            Assert.AreEqual("Cyborg Abomination Dragon", _superheroFaker.Name());
        }

        [Test]
        public void Name_returns_a_name_format_b()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Prefixes))
                .Returns("Cyborg");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Suffixes))
                .Returns("Dragon");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Descriptors))
                .Returns("Abomination");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroFaker.NameFormats))
                .Returns("{0} {1}");

            Assert.AreEqual("Cyborg Abomination", _superheroFaker.Name());
        }

        [Test]
        public void Name_returns_a_name_format_c()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Prefixes))
                .Returns("Cyborg");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Suffixes))
                .Returns("Dragon");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Descriptors))
                .Returns("Abomination");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroFaker.NameFormats))
                .Returns("{1} {2}");

            Assert.AreEqual("Abomination Dragon", _superheroFaker.Name());
        }

        [Test]
        public void Name_returns_a_name_format_d()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Prefixes))
                .Returns("Cyborg");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Suffixes))
                .Returns("Dragon");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroData.Descriptors))
                .Returns("Abomination");
            A.CallTo(() => _fakerContainer.Random.Element(SuperheroFaker.NameFormats))
                .Returns("{1}");

            Assert.AreEqual("Abomination", _superheroFaker.Name());
        }
    }
}
