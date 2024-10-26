using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    public struct WebsiteResponse
    {
        public int responseCode { get; set; }
        public long bytes { get; set; }
        public string url { get; set; }
        public string htmlBody { get; set; }

        public WebsiteResponse(int responseCode, long bytes, string url, string htmlBody)
        {
            this.responseCode = responseCode;
            this.bytes = bytes;
            this.url = url;
            this.htmlBody = htmlBody;
        }
    }
}
