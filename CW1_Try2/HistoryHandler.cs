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

    public class HistoryHandler
    {
        // our save file
        static string SAVE_FILE_PATH = Path.Combine(Form1.APP_DIR, "history.txt");

        private ListView listView;
        private List<HistoryItem> history;
        private int currentPointer;

        public HistoryHandler(ListView listView)
        {
            this.listView = listView;
            this.history = loadHistory(); // load history from file
            currentPointer = history.Count; // initialise pointer to end of history
        }

        public void addToHistory(HistoryItem item)
        {
            history.Add(item); // add to history
            currentPointer = history.Count - 1; // increment pointer to end
            updateListView();
        }

        public HistoryItem goBack()
        {
            if (!backExists()) return null; //check we have a page to go back to 

            currentPointer--;  // decrement pointer
            updateListView(); // update history view
            return history[currentPointer]; // return element from history
        }

        public HistoryItem? goForward()
        {
            if (!forwardExists()) return null; //check weh ave a page to go forward to

            currentPointer++; //increment pointer
            updateListView(); //update history view
            return history[currentPointer]; // return element from history
        }

        // this is like Stack.peek()
        public HistoryItem? mostRecent()
        {
            if (history.Count <= 0) return null; // check we have an element to return

            return history[history.Count - 1];
        }

        // helper methods
        public bool backExists()
        {
            return currentPointer > 0;
        }

        public bool forwardExists()
        {
            return currentPointer < history.Count - 1;
        }

        //used for highlighting the history item that we're on in the GUI
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

            // Read from the file and deserialize it
            var json = File.ReadAllText(SAVE_FILE_PATH);
            List<HistoryItem> savedHistory = new List<HistoryItem>();
            try
            {
                savedHistory = JsonSerializer.Deserialize<List<HistoryItem>>(json);
            }
            catch(Exception)
            {
                return savedHistory;
            }
            

            // update list view
            foreach (HistoryItem historyItem in savedHistory)
            {
                listView.Items.Add(new ListViewItem(historyItem.guiName) { Tag = historyItem }); // store 'tag' so we can easily reference object from history
            }

            return savedHistory;
        }
    }

}
