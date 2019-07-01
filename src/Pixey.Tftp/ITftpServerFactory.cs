using Tftp.Net;

namespace Pixey.Tftp
{
    public interface ITftpServerFactory
    {
        ITftpServer Create();
    }
}