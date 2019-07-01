using System;

namespace Pixey.Domain.BootLoaders.Exceptions
{
    public class InvalidBootLoaderFileNameException : Exception
    {
        public string FileName { get; }

        public InvalidBootLoaderFileNameException(string fileName)
        {
            FileName = fileName;
        }
    }
}
