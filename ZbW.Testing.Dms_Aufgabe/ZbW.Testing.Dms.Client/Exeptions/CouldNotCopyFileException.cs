using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]

namespace ZbW.Testing.Dms.Client.Exceptions
{
    internal class CouldNotCopyFileException : Exception
    {
        public CouldNotCopyFileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}