using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class LordOfTheRingsFakerTests
    {

        private static readonly LordOfTheRingsData Data = new LordOfTheRingsData();
        private IFakerContainer _fakerContainer;
        private ILordOfTheRingsFaker _lordOfTheRingsFaker;

        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _lordOfTheRingsFaker = new LordOfTheRingsFaker(_fakerContainer);
        }

        [Test]
        public void Character_Returns_a_Character()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Characters)))
                .Returns("Kaci");

            Assert.AreEqual("Kaci", _lordOfTheRingsFaker.Character());
        }

        [Test]
        public void Location_Returns_a_Location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Locations)))
                .Returns("Kaci");

            Assert.AreEqual("Kaci", _lordOfTheRingsFaker.Location());
        }

    }
}
