using System.IO;

namespace Pixey.Domain.BootLoaders
{
    public interface IBootLoaderService
    {
        Stream GetBootLoaderBinary(string requestedFileName);
    }
}