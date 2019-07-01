using Tftp.Net;

namespace Pixey.Tftp
{
    public class TftpServerFactory : ITftpServerFactory
    {
        public ITftpServer Create()
        {
            return new TftpServer();
        }
    }
}
