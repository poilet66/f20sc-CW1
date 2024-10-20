using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HistoryHandler
    {
        System.Windows.Forms.ListView listView;
        List<HistoryItem> history;
        int currentPointer;

        public HistoryHandler(System.Windows.Forms.ListView listView)
        {
            this.history = new List<HistoryItem>();
            this.listView = listView;
            currentPointer = -1;
        }

        public void addToHistory(HistoryItem item)
        {
            history.Add(item);
            currentPointer = history.Count - 1;
            updateListView();

        }

        public HistoryItem goBack()
        {
            if (!backExists()) return null;

            currentPointer--;
            updateListView();
            return history[currentPointer];
        }

        public HistoryItem? goForward()
        {
            if (!forwardExists()) return null; //TODO: Check this is correct

            currentPointer++;
            updateListView();
            return history[currentPointer];
        }

        public Boolean backExists()
        {
            return currentPointer > 0;
        }

        public Boolean forwardExists()
        {
            return currentPointer < history.Count - 1;
        }

        private void updateListView()
        {
            this.listView.SelectedItems.Clear();
            this.listView.Items[currentPointer].Selected = true;
        }

    }
}
