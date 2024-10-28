using System.Text.Json.Serialization;

namespace CW1_Try2
{
    public class HistoryItem
    {
        [JsonConstructor] // when constructing an item from saved JSON, use this constructor
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

        [JsonInclude] // we want this when we load in
        public string URL { get; set; }
        [JsonInclude] // same here
        public string guiName { get; set; }
        [JsonIgnore] // dont save this as by default page wont be cached when loaded from save
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
