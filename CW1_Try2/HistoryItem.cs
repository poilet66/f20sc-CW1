using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CW1_Try2
{
    public class HistoryItem
    {
        [JsonConstructor]
        public HistoryItem(string url, string guiName)
        {
            this.URL = url;
            this.guiName = guiName;
            //default fields for json serialized objects
            this.HTMLBody = "";
            this.cached = false;
        }

        // constructor of cached item (normally from non-cached)
        public HistoryItem(string url, string name, string html) : this(url, name)
        {
            this.HTMLBody = html;
            this.cached = true;
        }

        [JsonInclude]
        public string URL { get; set; }
        [JsonInclude]
        public string guiName { get; set; }
        [JsonIgnore]
        public string HTMLBody { get; set; }
        [JsonIgnore]
        public bool cached { get; set; }

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
