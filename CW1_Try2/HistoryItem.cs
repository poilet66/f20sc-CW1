using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    public class HistoryItem
    {
        public HistoryItem(string url, string name)
        {
            this.URL = url;
            this.guiName = name;
            this.HTMLBody = "";
            this.cached = false;
        }

        public HistoryItem(string url, string name, string html) : this(url, name)
        {
            this.HTMLBody = html;
            this.cached = true;
        }

        public string URL;
        public string guiName;
        public string HTMLBody;
        public bool cached;

        public void cacheHTML(string html)
        {
            this.HTMLBody = html;
            cached = true;
        }

        public bool isCached()
        {
            return this.cached;
        }

        public string getCachedHtml()
        {
            return this.HTMLBody;
        }

    }
}
