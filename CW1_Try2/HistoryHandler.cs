using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HistoryHandler
    {
        Stack<HistoryItem> history;

        public HistoryHandler()
        {
            this.history = new Stack<HistoryItem>();
        }

        public void addToHistory(HistoryItem item)
        {
            history.Push(item);
        }

        public HistoryItem? goBack()
        {
            if (history.Count == 0) return null;
            return history.Pop();
        }
        
    }

    public struct HistoryItem
    {
        public HistoryItem(string url, string name, string htmlBody)
        {
            this.URL = url;
            this.guiName = name;
            this.HTMLBody = htmlBody;
        }

        public string URL;
        public string guiName;
        public string HTMLBody;

    }
}
