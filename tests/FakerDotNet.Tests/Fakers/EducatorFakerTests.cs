using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class EducatorFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _educatorFaker = new EducatorFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private IEducatorFaker _educatorFaker;

        [Test]
        public void University_returns_a_university()
        {
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.Names))
                .Returns("Mallowtown");
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.Types))
                .Returns("Technical College");

            Assert.AreEqual("Mallowtown Technical College", _educatorFaker.University());
        }

        [Test]
        public void SecondarySchool_returns_a_secondary_school()
        {
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.Names))
                .Returns("Iceborough");
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.SecondaryNames))
                .Returns("Secondary College");

            Assert.AreEqual("Iceborough Secondary College", _educatorFaker.SecondarySchool());
        }

        [Test]
        public void Degree_returns_a_degree()
        {
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.DegreeTypes))
                .Returns("Associate Degree in");
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.DegreeSubjects))
                .Returns("Criminology");

            Assert.AreEqual("Associate Degree in Criminology", _educatorFaker.Degree());
        }

        [Test]
        public void CourseName_returns_a_course_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.DegreeSubjects))
                .Returns("Criminology");
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.CourseNumbers))
                .Returns("1##");
            A.CallTo(() => _fakerContainer.Number.Digit())
                .ReturnsNextFromSequence("0", "1");

            Assert.AreEqual("Criminology 101", _educatorFaker.CourseName());
        }

        [Test]
        public void Campus_returns_a_campus()
        {
            A.CallTo(() => _fakerContainer.Random.Element(EducatorData.Names))
                .Returns("Vertapple");

            Assert.AreEqual("Vertapple Campus", _educatorFaker.Campus());
        }
    }
}
