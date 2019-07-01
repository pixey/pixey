using System.Net;
using Tftp.Net;

namespace Pixey.Tftp
{
    public interface IPixeyTftpTransferFactory
    {
        IPixeyTftpTransfer CreateTftpTransfer(ITftpTransfer underlyingTransfer, EndPoint client);
    }
}