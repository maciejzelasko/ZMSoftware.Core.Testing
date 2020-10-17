using System;

namespace ZMSoftware.Core.Testing.Logging
{
    internal class TestLoggingScope : IDisposable
    {
        public static readonly TestLoggingScope Instance = new TestLoggingScope();

        private TestLoggingScope()
        {
        }

        public void Dispose()
        {
        }
    }
}
