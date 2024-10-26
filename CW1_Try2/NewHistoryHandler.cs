using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Windows.Forms;

    public class NewHistoryHandler
    {
        static string APP_DIR = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory);
        static string SAVE_FILE_PATH = Path.Combine(APP_DIR, "history.txt");

        private ListView listView;
        private List<HistoryItem> history;
        private int currentPointer;

        public NewHistoryHandler(ListView listView)
        {
            this.listView = listView;
            this.history = loadHistory();
            currentPointer = history.Count;
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
            if (!forwardExists()) return null;

            currentPointer++;
            updateListView();
            return history[currentPointer];
        }

        public HistoryItem? mostRecent()
        {
            if (history.Count <= 0) return null;

            return history[history.Count - 1];
        }

        public bool backExists()
        {
            return currentPointer > 0;
        }

        public bool forwardExists()
        {
            return currentPointer < history.Count - 1;
        }

        private void updateListView()
        {
            listView.SelectedItems.Clear();
            listView.Items.Clear();

            // Add each history item to the ListView and set the current pointer
            for (int i = 0; i < history.Count; i++)
            {
                var historyItem = history[i];
                var listViewItem = new ListViewItem(historyItem.guiName)
                {
                    Tag = historyItem
                };
                listView.Items.Add(listViewItem);
                if (i == currentPointer) listViewItem.Selected = true;
            }
        }

        public void saveHistory()
        {
            // Serialize the history list to JSON and write to the file
            string jsonString = JsonSerializer.Serialize(this.history);
            File.WriteAllText(SAVE_FILE_PATH, jsonString);
        }

        public List<HistoryItem> loadHistory()
        {
            // If no save file exists, return an empty history list
            if (!File.Exists(SAVE_FILE_PATH))
                return new List<HistoryItem>();

            // Read the JSON from the file and deserialize it
            var json = File.ReadAllText(SAVE_FILE_PATH);
            List<HistoryItem> savedHistory = JsonSerializer.Deserialize<List<HistoryItem>>(json) ?? new List<HistoryItem>();

            // Add each item to the ListView
            foreach (HistoryItem historyItem in savedHistory)
            {
                listView.Items.Add(new ListViewItem(historyItem.guiName) { Tag = historyItem });
            }

            return savedHistory;
        }
    }

}
