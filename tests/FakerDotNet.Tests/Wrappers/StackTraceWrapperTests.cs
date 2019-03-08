using FakerDotNet.Wrappers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Wrappers
{
    [TestFixture]
    [Parallelizable]
    public class StackTraceWrapperTests
    {
        [SetUp]
        public void SetUp()
        {
            _stackTraceWrapper = new StackTraceWrapper();
        }

        private IStackTraceWrapper _stackTraceWrapper;
        
        [Test]
        public void GetClassAtFrame_returns_the_class_at_a_frame_index_plus_one()
        {
            var result = _stackTraceWrapper.GetClassAtFrame(0);
            
            Assert.AreEqual("StackTraceWrapperTests", result);
        }

        [Test]
        public void GetClassAtFrame_returns_null_if_no_class_at_the_specified_frame_index()
        {
            var result = _stackTraceWrapper.GetClassAtFrame(99);

            Assert.IsNull(result);
        }
    }
}
