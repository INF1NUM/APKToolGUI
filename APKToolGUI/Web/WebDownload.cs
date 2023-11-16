using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APKToolGUI.Web
{
    public class WebDownload : WebClient
    {
        /// <summary>
        /// Time in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public WebDownload() : this(15000) { }

        public WebDownload(int timeout)
        {
            this.Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = this.Timeout;
            }
            return request;
        }
    }
}
