using System;

namespace iOps.Core
{
    [Serializable]
    public class iOpsException : Exception
    {
        public iOpsException(string message) : base(message)
        {
        }
    }
}