using System.Diagnostics;

namespace FakerDotNet.Wrappers
{
    internal interface IStackTraceWrapper
    {
        string GetClassAtFrame(int frameIndex);
    }
    
    internal class StackTraceWrapper : IStackTraceWrapper
    {
        public string GetClassAtFrame(int frameIndex)
        {
            return new StackTrace()
                .GetFrame(frameIndex + 1)
                ?.GetMethod()
                ?.ReflectedType
                ?.Name;
        }
    }
}
