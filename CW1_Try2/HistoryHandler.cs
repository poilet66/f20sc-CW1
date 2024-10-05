using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HistoryHandler
    {
        Stack<HistoryItem> backStack, forwardStack;

        public HistoryHandler()
        {
            this.backStack = new Stack<HistoryItem>();
            this.forwardStack = new Stack<HistoryItem>();
        }

        public void addItem(HistoryItem item)
        {
            backStack.Push(item);
        }

        public HistoryItem? goBack(HistoryItem? currentPage)
        {
            //If nothing to go back to return null
            if (backStack.Count == 0) return null;
            // Otherwise, save current page and return topmost history
            if (currentPage != null)
            {
                forwardStack.Push(currentPage.Value);
            }
            return backStack.Pop();
        }

        public HistoryItem? forward(HistoryItem? currentPage)
        {
            // If nothing to go forward to return null
            if (forwardStack.Count == 0) return null;
            // Otherwise, save current page to history and go forward
            if (currentPage != null)
            {
                backStack.Push(currentPage.Value);
            }
            return forwardStack.Pop();
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
