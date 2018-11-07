using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Extensions;

namespace Locust.Network
{
    public class IPv4
    {
        public string A { get; protected set; }
        public string B { get; protected set; }
        public string C { get; protected set; }
        public string D { get; protected set; }

        public string[] Segments
        {
            get
            {
                return new string[] { "0", "0", "0", "0" };
            }
        }
        public IPv4()
        { }
        public IPv4(string ip)
        {
            if (!string.IsNullOrEmpty(ip))
            {
                if (ip == "::1")
                {
                    ip = "127.0.0.1";
                }

                var arr = ip.Split(".", MyStringSplitOptions.TrimAndRemoveEmptyEntries);
                var count = 0;

                foreach (var part in arr)
                {
                    byte x;
                    if (part == "*")
                    {
                        switch (count)
                        {
                            case 0:
                                A = part;
                                break;
                            case 1:
                                B = part;
                                break;
                            case 2:
                                C = part;
                                break;
                            case 3:
                                D = part;
                                break;
                        }
                    }
                    else
                    {
                        if (byte.TryParse(part, out x))
                        {
                            switch (count)
                            {
                                case 0:
                                    A = x.ToString();
                                    break;
                                case 1:
                                    B = x.ToString();
                                    break;
                                case 2:
                                    C = x.ToString();
                                    break;
                                case 3:
                                    D = x.ToString();
                                    break;
                            }
                        }
                        else
                        {
                            switch (count)
                            {
                                case 0:
                                    A = "0";
                                    break;
                                case 1:
                                    B = "0";
                                    break;
                                case 2:
                                    C = "0";
                                    break;
                                case 3:
                                    D = "0";
                                    break;
                            }
                        }
                    }
                    count++;
                }
            }
        }

        public bool Matches(IPv4 ip)
        {
            return
                (this.A == ip.A || this.A == "*" || ip.A == "*") &&
                (this.B == ip.B || this.B == "*" || ip.B == "*") &&
                (this.C == ip.C || this.C == "*" || ip.C == "*") &&
                (this.D == ip.D || this.D == "*" || ip.D == "*");
        }
        public bool Matches(string ip)
        {
            return this.Matches(new IPv4(ip));
        }

        public bool Matches(IEnumerable<string> ipList)
        {
            var result = false;
            if (ipList != null)
            {
                foreach (var ip in ipList)
                {
                    if (this.Matches(new IPv4(ip)))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        public bool Matches(IEnumerable<IPv4> ipList)
        {
            var result = false;
            if (ipList != null)
            {
                foreach (var ip in ipList)
                {
                    if (this.Matches(ip))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        public override string ToString()
        {
            return A + "." + B + "." + C + "." + D;
        }

        public bool IsMask()
        {
            return A == "*" || B == "*" || C == "*" || D == "*";
        }
        public bool IsPrivate()
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var is24BitBlock = A == "10";
            if (is24BitBlock) return true; // Return to prevent further processing
            var b = SafeClrConvert.ToByte(B);
            var is20BitBlock = A == "172" && B != "*" && b >= 16 && b <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = A == "192" && B == "168";
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = A == "169" && B == "254";

            return isLinkLocalAddress;

        }
        public static implicit operator IPv4(string t)
        {
            return new IPv4(t);
        }
        public static implicit operator string(IPv4 f)
        {
            return f.ToString();
        }
    }
}
