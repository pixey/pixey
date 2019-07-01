using System.IO;

namespace Pixey.Domain.BootLoaders
{
    public interface IBootLoaderService
    {
        Stream GetBootLoaderBinaryByFileName(string fileName);
    }
}