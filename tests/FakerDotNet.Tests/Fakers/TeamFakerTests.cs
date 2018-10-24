using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class TeamFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _teamFaker = new TeamFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private TeamFaker _teamFaker;

        [Test]
        public void Creature_returns_a_creature()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TeamData.Creatures))
                .Returns("buffalo");

            Assert.AreEqual("buffalo", _teamFaker.Creature());
        }

        [Test]
        public void Name_returns_a_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TeamData.Creatures))
                .Returns("buffalo");
            A.CallTo(() => _fakerContainer.Address.State())
                .Returns("Kansas");

            Assert.AreEqual("Kansas buffalo", _teamFaker.Name());
        }

        [Test]
        public void State_returns_a_state()
        {
            A.CallTo(() => _fakerContainer.Address.State())
                .Returns("Kansas");

            Assert.AreEqual("Kansas", _teamFaker.State());
        }

        [Test]
        public void Sport_returns_a_sport()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TeamData.Sports))
                .Returns("hockey");

            Assert.AreEqual("hockey", _teamFaker.Sport());
        }

        [Test]
        public void Mascot_returns_a_mascot()
        {
            A.CallTo(() => _fakerContainer.Random.Element(TeamData.Mascots))
                .Returns("K.C. Wolf");

            Assert.AreEqual("K.C. Wolf", _teamFaker.Mascot());
        }
    }
}
