using System.Net;

namespace Pixey.Domain.Diagnostics.Events
{
    public class ClientInfo
    {
        public IPAddress IpAddress { get; }

        public ClientInfo(IPAddress ipAddress)
        {
            IpAddress = ipAddress;
            // ipAddress.MapToIPv4().ToString();
        }



        // TODO: Add ctor with MAC address etc.

        public override string ToString()
        {
            return IpAddress?.ToString();
        }
    }
}