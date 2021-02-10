using System;

namespace ZMSoftware.Core.Testing.Logging
{
    internal class TestLoggingScope : IDisposable
    {
        public static readonly TestLoggingScope Instance = new ();

        private TestLoggingScope()
        {
        }

        public void Dispose()
        {
        }
    }
}
