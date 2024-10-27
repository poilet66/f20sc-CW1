﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HistoryHandler
    {
        static string SAVE_FILE_PATH = Path.Combine(Form1.APP_DIR, "history.txt");

        System.Windows.Forms.ListView listView;
        List<HistoryItem> history;
        int currentPointer;

        public HistoryHandler(System.Windows.Forms.ListView listView)
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

        public void saveHistory()
        {
            File.Delete(SAVE_FILE_PATH);
            using (StreamWriter writer = new StreamWriter(SAVE_FILE_PATH))
            {
                foreach (HistoryItem historyItem in this.history)
                {
                    writer.WriteLine(historyItem.URL);
                }
            }
        }

        public List<HistoryItem> loadHistory()
        {
            using (StreamReader reader = new StreamReader(SAVE_FILE_PATH))
            {
                List<HistoryItem> savedHistory = new List<HistoryItem>();
                String line;

                // Read file line by line, adding lines (favourites) to favourite list
                while ((line = reader.ReadLine()) != null)
                {
                    string title = Form1.getDomain(line);
                    savedHistory.Add(new HistoryItem(line, title));
                    listView.Items.Add(title);
                    
                }

                return savedHistory;
            }
        }

    }
}
