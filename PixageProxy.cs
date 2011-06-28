using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ProxyLib
{
    public class PixageProxy : IWebProxy
    {
        public PixageProxy()
        {
            string dir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string pfile = System.IO.Path.Combine(dir, "Proxy.txt");
            if (System.IO.File.Exists(pfile))
            {
                string[] lines = System.IO.File.ReadAllLines(pfile);
                url = lines[0];
                if (lines[1] == "#")
                    creds = new NetworkCredential();
                else
                    creds = new NetworkCredential(lines[1], lines[2]);

            }
        }

        ICredentials creds;
        string url;

        public ICredentials Credentials
        {
            get
            {
                return creds;
            }
            set { creds = value; }
        }
        public Uri GetProxy(Uri destination)
        {
            return new Uri(url);
        }
        public bool IsBypassed(Uri host) { return false; }
    }
}
