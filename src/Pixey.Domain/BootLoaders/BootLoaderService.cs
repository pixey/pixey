using System;
using System.IO;
using Pixey.Domain.BootLoaders.Exceptions;

namespace Pixey.Domain.BootLoaders
{
    public class BootLoaderService : IBootLoaderService
    {
        private readonly BootTypeToFileNameMapper _mapper;

        public BootLoaderService()
        {
            _mapper = new BootTypeToFileNameMapper();
        }

        public Stream GetBootLoaderBinaryByFileName(string fileName)
        {
            if (!_mapper.TryGetBootType(fileName, out var bootType))
            {
                throw new InvalidBootLoaderFileNameException(fileName);
            }

            // Fetch currently active version (?)

            throw new NotImplementedException();
        }

        
    }
}