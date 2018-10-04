using FakerDotNet.Fakers;
using FakerDotNet.Tests.Helpers;
using FakerDotNet.Wrappers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class BooleanFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _randomWrapper = new RandomWrapper();
            _booleanFaker = new BooleanFaker(_randomWrapper);
        }

        private IRandomWrapper _randomWrapper;
        private IBooleanFaker _booleanFaker;

        [Test]
        public void Boolean_returns_true_or_false()
        {
            var trueResults = 0;
            var falseResults = 0;
            
            100.Times(() =>
            {
                if (_booleanFaker.Boolean())
                    trueResults++;
                else
                    falseResults++;
            });

            Assert.Greater(trueResults, 0);
            Assert.Greater(falseResults, 0);
        }

        [Test]
        public void Boolean_always_returns_false_when_trueBias_is_zero()
        {
            100.Times(() => Assert.False(_booleanFaker.Boolean(0)));
        }
        
        [Test]
        public void Boolean_always_returns_true_when_trueBias_is_one()
        {
            100.Times(() => Assert.True(_booleanFaker.Boolean(1)));
        }
    }
}
