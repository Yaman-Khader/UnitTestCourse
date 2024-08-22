using NetworkUtility.DNS;
using System.Net.NetworkInformation;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDns _dns;

        public NetworkService(IDns dns)
        {
            _dns = dns;
        }
        public string SendPing()
        {
            var dnsSuccess = _dns.SendDNS();
            if (dnsSuccess)
                return "Success: Ping Sent!";
            else
                return "Failed: Ping Not Sent!";

        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {

            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1,

            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingsOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,

                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,

                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1,

                }


        };
            return pingsOptions;


        }


    }
}
