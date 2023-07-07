using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseQueryTest
{
    internal class NetworkLibrary
    {
        public static string GetInternalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(var ip in host.AddressList) {
                if(ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static async Task<string> GetExternalIPAddressAsync()
        {
            string externalip = await new HttpClient().GetStringAsync("http://ipinfo.io/ip");

            if(String.IsNullOrWhiteSpace(externalip)) {
                externalip = GetInternalIPAddress();//null경우 Get Internal IP를 가져오게 한다.
            }

            return externalip;
        }
    }
}
