using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HistoryHandlerNew
    {
        List<HistoryItem> history;
        int currentPointer;

        public HistoryHandlerNew()
        {
            this.history = new List<HistoryItem>();
            currentPointer = -1;
        }

        public void addToHistory(HistoryItem item)
        {
            history.Add(item);
            currentPointer = history.Count - 1;

        }

        public HistoryItem? goBack()
        {
            if (!backExists()) return null;

            return history[--currentPointer];
        }

        public HistoryItem? goForward()
        {
            if (!forwardExists()) return null; //TODO: Check this is correct

            return history[++currentPointer];
        }

        public Boolean backExists()
        {
            return currentPointer > 0;
        }

        public Boolean forwardExists()
        {
            return currentPointer < history.Count - 1;
        }
    }
}
