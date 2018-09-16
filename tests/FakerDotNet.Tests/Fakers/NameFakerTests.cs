using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class NameFakerTests
    {
        private static readonly NameData Data = new NameData();
        
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _nameFaker = new NameFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private INameFaker _nameFaker;

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.FirstNames)))
                .Returns("Tyshawn");
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.LastNames)))
                .Returns("Johns Sr.");
            
            Assert.AreEqual("Tyshawn Johns Sr.", _nameFaker.Name());
        }

        [Test]
        public void NameWithMiddle_returns_name_with_a_middle_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.FirstNames)))
                .ReturnsNextFromSequence("Aditya", "Elton");
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.LastNames)))
                .Returns("Douglas");
            
            Assert.AreEqual("Aditya Elton Douglas", _nameFaker.NameWithMiddle());
        }

        [Test]
        public void FirstName_returns_a_first_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.FirstNames)))
                .Returns("Kaci");
            
            Assert.AreEqual("Kaci", _nameFaker.FirstName());
        }

        [Test]
        public void LastName_returns_a_last_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.LastNames)))
                .Returns("Ernser");
            
            Assert.AreEqual("Ernser", _nameFaker.LastName());
        }

        [Test]
        public void Prefix_returns_a_prefix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Prefixes)))
                .Returns("Mr.");
            
            Assert.AreEqual("Mr.", _nameFaker.Prefix());
        }

        [Test]
        public void Suffix_returns_a_suffix()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Suffixes)))
                .Returns("IV");
            
            Assert.AreEqual("IV", _nameFaker.Suffix());
        }

        [Test]
        public void Title_returns_a_title()
        {
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.TitleDescriptors)))
                .Returns("Legacy");
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.TitleLevels)))
                .Returns("Creative");
            A.CallTo(() => _fakerContainer.Random.Element(A<IEnumerable<string>>.That.IsSameSequenceAs(Data.TitleJobs)))
                .Returns("Director");
            
            Assert.AreEqual("Legacy Creative Director", _nameFaker.Title());
        }
    }
}
