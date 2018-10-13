using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class FriendsFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _friendsFaker = new FriendsFaker(_fakerContainer);
        }

        private static readonly FriendsData Data = new FriendsData();

        private IFakerContainer _fakerContainer;
        private IFriendsFaker _friendsFaker;

        [Test]
        public void Character_returns_a_character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Characters)))
                .Returns("Rachel Green");

            Assert.AreEqual("Rachel Green", _friendsFaker.Character());
        }

        [Test]
        public void Location_returns_a_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Locations)))
                .Returns("15 Yemen Road, Yemen");

            Assert.AreEqual("15 Yemen Road, Yemen", _friendsFaker.Location());
        }

        [Test]
        public void Quote_returns_a_quote()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Quotes)))
                .Returns("Forty-two to twenty-one! Like the turkey, Ross is done!");

            Assert.AreEqual("Forty-two to twenty-one! Like the turkey, Ross is done!", _friendsFaker.Quote());
        }
    }
}
