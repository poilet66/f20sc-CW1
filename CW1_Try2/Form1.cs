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

        private HttpClient client;
        private FavouritesHandler handler;
        private HistoryHandler historyHandler;

        public Form1()
        {
            InitializeComponent();
            this.client = new HttpClient();
            this.handler = new FavouritesHandler();
            this.historyHandler = new HistoryHandler(this.listView1);
            setFavouritesInCombobox();

        }

        private void setFavouritesInCombobox()
        {
            foreach (string favourite in handler.getFavourites())
            {
                this.comboBox1.Items.Add(favourite);
            }
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {

            this.handler.saveFavourites();
            this.historyHandler.saveHistory();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("testing");
            TextBox textbox = (TextBox)sender;

            foreach (string s in handler.getFavourites())
            {
                if (string.Equals(s, textbox.Text))
                {
                    button2.Text = "★";
                    return;
                }
            }
            button2.Text = "☆";
        }

        private void onTextboxEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                TextBox box = (TextBox)sender;
                queryURL(box.Text, null);
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
                if (string.Equals(newFave, s))
                {
                    handler.removeFavourite(s);
                    comboBox1.Items.Remove(s);
                    updateButtonImage();
                    return;
                }
            }
            // If URL not empty
            if (!string.Equals(newFave, ""))
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
            if (!historyHandler.backExists()) return;

            HistoryItem item = historyHandler.goBack(); // We can be sure its not null now

            // If history item has cache, use it
            if(item.isCached())
            {
                urlTextBox.Text = item.URL;
                htmlTextbox.Text = item.HTMLBody;
                return;
            }

            //Otherwise, re-query to render
            queryURL(item.URL, item);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (handler.getFavourites().Contains(urlTextBox.Text))
            {
                handler.removeFavourite(urlTextBox.Text);
                comboBox1.Items.Remove(urlTextBox.Text);
                updateButtonImage();
            }
            else
            {
                handler.addFavourite(urlTextBox.Text);
                comboBox1.Items.Add(urlTextBox.Text);
                updateButtonImage();
            }

        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (!historyHandler.forwardExists()) return;

            HistoryItem item = historyHandler.goForward(); // We can be sure its not null now

            // If history item has cache, use it
            if (item.isCached())
            {
                urlTextBox.Text = item.URL;
                htmlTextbox.Text = item.HTMLBody;
                return;
            }

            //Otherwise, re-query to render
            queryURL(item.URL, item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String output = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                output += item.Text + "\r\n";
            }
            htmlTextbox.Text = output;
        }

        public static String GetTitle(string htmlBody)
        {
            string ret = "";

            string pattern = @"<title[^>]*>([\s\S]*?)<\/title>";
            Match match = Regex.Match(htmlBody, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ret = match.Groups[1].Value;
            }
            return ret;
        }

        private async Task<string> GetHtmlBody(string url)
        {
            using HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            // Await and get the response content as a string
            string content = await response.Content.ReadAsStringAsync();

            // Return the string content
            return content;
        }

        private async void queryURL(string url, HistoryItem? cacheToUpdate)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);

                codeTextbox.Text = "" + ((int)response.StatusCode) + " - " + response.StatusCode.ToString(); //TODO: Use string formatting to make this nicer
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                htmlTextbox.Text = responseBody.Trim();
                titleTextbox.Text = GetTitle(responseBody);

                if (cacheToUpdate != null)
                {
                    cacheToUpdate.cacheHTML(responseBody);
                    return;
                }

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
                historyHandler.addToHistory(new HistoryItem(url, domain));
            } 
            catch (InvalidOperationException e)
            {
                titleTextbox.Text = "<ERROR> Not a valid HTTP Request <ERROR>";
            }
            catch (HttpRequestException e)
            {
                titleTextbox.Text = "<ERROR> HTTPException <ERROR>";
                return;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            queryURL(urlTextBox.Text, null);
        }

        public static string? getTitle(string url)
        {
            string domain = url;
            string pattern = @"https?:\/\/(?:www\.)?([^\/]+)";
            Match match = Regex.Match(url, pattern);
            if (match.Success)
            {
                // match.Groups[1] contains the domain (e.g., google.com)
                domain = match.Groups[1].Value;
                return domain;
            }
            return null;
        }
    }
}
