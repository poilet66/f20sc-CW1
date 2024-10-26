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
        private NewHistoryHandler historyHandler;
        private FavouriteItem currentPage;

        public Form1()
        {
            InitializeComponent();
            this.client = new HttpClient();
            this.handler = new FavouritesHandler();
            this.historyHandler = new NewHistoryHandler(this.historyView);
            setFavouritesInCombobox();

        }

        private void setFavouritesInCombobox()
        {
            foreach (FavouriteItem item in handler.getFavourites())
            {
                this.favouritesBox.Items.Add(item);
            }
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {

            this.handler.saveFavourites();
            this.historyHandler.saveHistory();
        }


        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;

            foreach (FavouriteItem favourite in handler.getFavourites())
            {
                if (string.Equals(favourite.Url, textbox.Text))
                {
                    favouriteButton.Text = "★";
                    return;
                }
            }
            favouriteButton.Text = "☆";
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
            if (e.KeyChar == (char)Keys.Return)
            {
                ComboBox box = (ComboBox)sender;
                FavouriteItem item = (FavouriteItem)box.SelectedItem;
                urlTextBox.Text = item.Url;
                titleTextbox.Text = item.Name;

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newFave = urlTextBox.Text;

            foreach (FavouriteItem item in handler.getFavourites())
            {
                if (string.Equals(newFave, item.Url))
                {
                    handler.removeFavourite(item);
                    favouritesBox.Items.Remove(item);
                    updateButtonImage();
                    return;
                }
            }
            // If URL not empty
            if (!string.Equals(newFave, ""))
            {
                //TODO: Add valid URL validation
                handler.addFavourite(new FavouriteItem(currentPage.Url, titleTextbox.Text));
                favouritesBox.Items.Add(urlTextBox.Text);
                updateButtonImage();
            }
        }

        private void updateButtonImage()
        {
            favouriteButton.Text = (string.Equals(favouriteButton.Text, "★") ? "☆" : "★");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (!historyHandler.backExists()) return;

            HistoryItem item = historyHandler.goBack(); // We can be sure its not null now

            // If history item has cache, use it
            if (item.isCached())
            {
                urlTextBox.Text = item.URL;
                htmlTextbox.Text = item.HTMLBody;
                titleTextbox.Text = GetTitle(item.HTMLBody).Trim();
                return;
            }

            //Otherwise, re-query to render
            queryURL(item.URL, item);
        }

        private void favouriteButton_Click(object sender, EventArgs e)
        {
            foreach (FavouriteItem item in handler.getFavourites())
            {
                if(String.Equals(item.Url, urlTextBox.Text))
                {
                    handler.removeFavourite(item);
                    favouritesBox.Items.Remove(item);
                    updateButtonImage();
                    return;
                }
            }
            if (currentPage == null) return;
            FavouriteItem newItem = new FavouriteItem(currentPage.Url, titleTextbox.Text);
            handler.addFavourite(newItem);
            favouritesBox.Items.Add(newItem);
            updateButtonImage();

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
                titleTextbox.Text = GetTitle(item.HTMLBody).Trim();
                return;
            }

            //Otherwise, re-query to render
            queryURL(item.URL, item);
        }

        private async void bulkButton_Click(object sender, EventArgs e)
        {
            String output = "";
            if(String.Equals(urlTextBox.Text, ""))
            {
                titleTextbox.Text = "<ERROR> Enter a valid bulk file name <ERROR>";
                return;
            }
            foreach (ListViewItem item in historyView.SelectedItems)
            {
                WebsiteResponse response = await fetchWebsite(((HistoryItem)item.Tag).URL);
                output += $"{response.responseCode} {response.bytes} {response.url}\r\n"; ;

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

        private async void queryURL(string url, HistoryItem? cacheToUpdate)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);

                urlTextBox.Text = url;
                codeTextbox.Text = "" + ((int)response.StatusCode) + " - " + response.StatusCode.ToString(); //TODO: Use string formatting to make this nicer
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                string title = GetTitle(responseBody).Trim();
                htmlTextbox.Text = responseBody.Trim();
                titleTextbox.Text = title;
                currentPage = new FavouriteItem(url, title);

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
                    
                }
                HistoryItem newItem = new HistoryItem(url, domain);

                // add to listview
                historyView.Items.Add(new ListViewItem(newItem.guiName) { Tag = newItem });
                // Add to logical history
                historyHandler.addToHistory(newItem);
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            queryURL(urlTextBox.Text, null);
        }

        public static string? getDomain(string url)
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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (historyHandler.mostRecent() == null) return;
            HistoryItem item = historyHandler.mostRecent();
            titleTextbox.Text = "";
            htmlTextbox.Text = "";
            queryURL(item.URL, item);
           
        }

        private async Task<WebsiteResponse> fetchWebsite(string url)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Throws if the status code is not 2xx

                // Get the response body as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Populate and return the WebsiteResponse struct
                return new WebsiteResponse((int)response.StatusCode, response.Content.Headers.ContentLength ?? 0, url, responseBody);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is HttpRequestException)
            {
                // Return a default WebsiteResponse with an error code or message
                return new WebsiteResponse(0, 0, url, "");
            }
        }
    }

}
