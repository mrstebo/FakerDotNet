using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class UniversityFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _universityFaker = new UniversityFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private IUniversityFaker _universityFaker;

        [Test]
        public void Name_returns_a_University_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Names))
                .Returns("South Texas College");

            Assert.AreEqual("South Texas College", _universityFaker.Name());
        }

        [Test]
        public void Name_runs_placeholders_through_the_IFakeFaker()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Names))
                .Returns("{Name.LastName} {Suffix}");
            A.CallTo(() => _fakerContainer.Name.LastName())
                .Returns("test1");
            A.CallTo(() => _fakerContainer.University.Suffix())
                .Returns("test2");

            Assert.AreEqual("test1 test2", _universityFaker.Name());
        }

        [Test]
        public void Prefix_returns_a_University_prefix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Prefixes))
                .Returns("North");

            Assert.AreEqual("North", _universityFaker.Prefix());
        }

        [Test]
        public void Suffix_returns_a_University_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.Suffixes))
                .Returns("Institute");

            Assert.AreEqual("Institute", _universityFaker.Suffix());
        }

        [Test]
        public void GreekOrganization_returns_a_GreekOrganization()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.GreekAlphabets))
                .Returns("Α");

            Assert.AreEqual("ΑΑΑ", _universityFaker.GreekOrganization());
        }

        [Test]
        public void GreekAlphabet_returns_a_GreekAlphabet()
        {
            A.CallTo(() => _fakerContainer.Random.Element(UniversityData.GreekAlphabets))
                .Returns("Α");

            Assert.AreEqual("Α", _universityFaker.GreekAlphabet());
        }
    }
}
