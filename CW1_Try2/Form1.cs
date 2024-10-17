using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CW1_Try2
{
    public partial class Form1 : Form
    {

        HttpClient client;
        FavouritesHandler handler;
        HistoryHandler historyHandler;

        HistoryHandlerNew historyHandler1;

        public Form1()
        {
            InitializeComponent();
            this.client = new HttpClient();
            this.handler = new FavouritesHandler();
            this.historyHandler = new HistoryHandler();
            this.historyHandler1 = new HistoryHandlerNew();
            setFavouritesInCombobox();

        }

        private void setFavouritesInCombobox()
        {
            foreach(string favourite in handler.getFavourites())
            {
                this.comboBox1.Items.Add(favourite);
            }
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            
            this.handler.saveFavourites();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("testing");
            TextBox textbox = (TextBox)sender;

            foreach( string s in handler.getFavourites())
            {
                if(string.Equals(s, textbox.Text))
                {
                    button2.Text = "★";
                    return;
                }
            }
            button2.Text = "☆";
        }

        private async void onTextboxEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                TextBox box = (TextBox)sender;
                using HttpResponseMessage response = await client.GetAsync(box.Text);
                label2.Text = "" + ((int) response.StatusCode) + " - " + response.StatusCode.ToString(); //TODO: Use string formatting to make this nicer
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                textBox2.Text = responseBody;

                string url = box.Text;
                string domain = url;
                string pattern = @"https?:\/\/(?:www\.)?([^\/]+)";
                Match match = Regex.Match(url, pattern);
                if (match.Success)
                {
                    // match.Groups[1] contains the domain (e.g., google.com)
                    domain = match.Groups[1].Value;
                    listView1.Items.Add(new ListViewItem(domain));
                }

                // Add to history
                historyHandler.addItem(new HistoryItem(url, domain, responseBody));
                historyHandler1.addToHistory(new HistoryItem(url, domain, responseBody));

            }
        }

        private void testFunc(object sender, KeyPressEventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            urlTextBox.Text = box.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newFave = urlTextBox.Text;

            foreach (string s in handler.getFavourites())
            {
                if(string.Equals(newFave, s))
                {
                    handler.removeFavourite(s);
                    comboBox1.Items.Remove(s);
                    updateButtonImage();
                    return;
                }
            }
            // If URL not empty
            if(!string.Equals(newFave, ""))
            {
                //TODO: Add valid URL validation
                handler.addFavourite(urlTextBox.Text);
                comboBox1.Items.Add(urlTextBox.Text);
                updateButtonImage();
            }
        }

        private void updateButtonImage()
        {
            button2.Text = (string.Equals(button2.Text, "★") ? "☆" : "★");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            /*
            // Try go back
            HistoryItem? currentPage = null;
            if(textBox2.Text != "")
            {
                currentPage = new HistoryItem(urlTextBox.Text, urlTextBox.Text, textBox2.Text);
            }
            // If valid history
            HistoryItem? backPage = historyHandler.goBack(currentPage);
            if(backPage != null)
            {
                urlTextBox.Text = backPage.Value.URL;
                textBox2.Text = backPage.Value.HTMLBody;
            }
            */

            if (!historyHandler1.backExists()) return;

            HistoryItem item = historyHandler1.goBack().Value; // We can be sure its not null now
            urlTextBox.Text = item.URL;
            textBox2.Text = item.HTMLBody;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (handler.getFavourites().Contains(urlTextBox.Text))
            {
                handler.removeFavourite(urlTextBox.Text);
                comboBox1.Items.Remove(urlTextBox.Text);
                updateButtonImage();
            } else
            {
                handler.addFavourite(urlTextBox.Text);
                comboBox1.Items.Add(urlTextBox.Text);
                updateButtonImage();
            }
            
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (!historyHandler1.forwardExists()) return;

            HistoryItem item = historyHandler1.goForward().Value;
            urlTextBox.Text = item.URL;
            textBox2.Text = item.HTMLBody;
        }
    }
}
