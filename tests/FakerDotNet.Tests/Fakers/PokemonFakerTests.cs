using System.Collections.Generic;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class PokemonFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _pokemonFaker = new PokemonFaker(_fakerContainer);
        }
        
        private static readonly PokemonData Data = new PokemonData();

        private IFakerContainer _fakerContainer;
        private IPokemonFaker _pokemonFaker;

        [Test]
        public void Name_returns_a_Pokemon_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Names)))
                .Returns("Pikachu");
            
            Assert.AreEqual("Pikachu", _pokemonFaker.Name());
        }

        [Test]
        public void Location_returns_a_Pokemon_location()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Locations)))
                .Returns("Pallet Town");
            
            Assert.AreEqual("Pallet Town", _pokemonFaker.Location());
        }

        [Test]
        public void Move_returns_a_Pokemon_move()
        {
            A.CallTo(() => _fakerContainer.Random.Element(
                    A<IEnumerable<string>>.That.IsSameSequenceAs(Data.Moves)))
                .Returns("Thunder Shock");
            
            Assert.AreEqual("Thunder Shock", _pokemonFaker.Move());
        }
    }
}