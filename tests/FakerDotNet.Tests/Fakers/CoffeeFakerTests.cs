using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class CoffeeFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _coffeeFaker = new CoffeeFaker(_fakerContainer);
        }

        private IFakerContainer _fakerContainer;
        private ICoffeeFaker _coffeeFaker;

        [Test]
        public void BlendName_returns_a_blend_name()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.BlendNamePrefixes))
                .Returns("Summer");
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.BlendNameSuffixes))
                .Returns("Solstice");
            
            Assert.AreEqual("Summer Solstice", _coffeeFaker.BlendName());
        }
        
        [Test]
        public void Origin_returns_an_origin()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.CountriesWithRegions.Keys))
                .Returns("Guatemala");
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.CountriesWithRegions["Guatemala"]))
                .Returns("Antigua");
            
            Assert.AreEqual("Antigua, Guatemala", _coffeeFaker.Origin());
        }
        
        [Test]
        public void Variety_returns_a_variety()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.Varieties))
                .Returns("Pacas");
            
            Assert.AreEqual("Pacas", _coffeeFaker.Variety());
        }
        
        [Test]
        public void Notes_returns_some_notes()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.Intensifiers))
                .Returns("balanced");
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.Bodies))
                .Returns("silky");
            A.CallTo(() => _fakerContainer.Random.Assortment(CoffeeData.Descriptors, 3))
                .Returns(new[] {"marzipan", "orange-creamsicle", "bergamot"});
            
            Assert.AreEqual("balanced, silky, marzipan, orange-creamsicle, bergamot", _coffeeFaker.Notes());
        }
        
        [Test]
        public void Intensifier_returns_an_intensifier()
        {
            A.CallTo(() => _fakerContainer.Random.Element(CoffeeData.Intensifiers))
                .Returns("quick");
            
            Assert.AreEqual("quick", _coffeeFaker.Intensifier());
        }
    }
}
