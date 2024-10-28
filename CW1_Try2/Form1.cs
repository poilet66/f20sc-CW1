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
using System.IO;

namespace CW1_Try2
{
    public partial class Form1 : Form
    {
        // we can use this base directory across handlers as it'll be constant
        public static readonly string APP_DIR = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory);
        private HttpClient client;
        private FavouritesHandler handler;
        private HistoryHandler historyHandler;
        private FavouriteItem currentPage;
        private HomepageHandler homepageHandler;

        public Form1()
        {
            // init handlers (they will call their initialising methods internally)
            InitializeComponent();
            this.client = new HttpClient();
            this.handler = new FavouritesHandler();
            this.historyHandler = new HistoryHandler(this.historyView);
            this.homepageHandler = new HomepageHandler();
            if(homepageHandler.HomepageUrl != null)
            {
                if (!String.Equals(homepageHandler.HomepageUrl, ""))
                {
                    urlTextBox.Text = homepageHandler.HomepageUrl;
                    queryURL(homepageHandler.HomepageUrl, null);
                }
            }
            setFavouritesInCombobox();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // saving logic here
        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {

            this.handler.saveFavourites();
            this.historyHandler.saveHistory();
            this.homepageHandler.saveHomepage();
        }

        // update favourites box
        private void setFavouritesInCombobox()
        {
            foreach (FavouriteItem item in handler.getFavourites())
            {
                this.favouritesBox.Items.Add(item);
            }
        }

        // search button click
        private void searchButton_Click(object sender, EventArgs e)
        {
            queryURL(urlTextBox.Text, null);
        }

        // refresh button click
        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (historyHandler.mostRecent() == null) return; // if no website to refresh return
            HistoryItem item = historyHandler.mostRecent(); // otherwise, get most recent website and requery it
            titleTextbox.Text = "";
            htmlTextbox.Text = "";
            queryURL(item.URL, item);

        }

        // logic for checking whether entered URL is already favourited
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

        // key handler for ENTER listening on searchbar
        private void onTextboxEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                TextBox box = (TextBox)sender;
                queryURL(box.Text, null);
            }
        }

        // listener for checking if favourite item needs to be moved to url
        private void favouriteBox_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ComboBox box = (ComboBox)sender;
                FavouriteItem item = (FavouriteItem)box.SelectedItem;
                urlTextBox.Text = item.Url;
                titleTextbox.Text = item.Name;

            }
        }

        // new favourite button listener (either favourite or unfavourite)
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
                handler.addFavourite(new FavouriteItem(currentPage.Url, titleTextbox.Text));
                favouritesBox.Items.Add(urlTextBox.Text);
                updateButtonImage();
            }
        }

        private void favouriteButton_Click(object sender, EventArgs e)
        {
            foreach (FavouriteItem item in handler.getFavourites())
            {
                if (String.Equals(item.Url, urlTextBox.Text))
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

        // helper method for toggling favourite button
        private void updateButtonImage()
        {
            favouriteButton.Text = (string.Equals(favouriteButton.Text, "★") ? "☆" : "★");
        }

        // history navigation logic
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

        // home page methods
        private void homepageButton_Click(object sender, EventArgs e)
        {
            urlTextBox.Text = homepageHandler.HomepageUrl;
        }

        // save home page
        private void editHomepageButton_Click(object sender, EventArgs e)
        {
            homepageHandler.HomepageUrl = urlTextBox.Text;
            titleTextbox.Text = "Homepage saved!";
        }

        // bulk download button click
        private async void bulkButton_Click(object sender, EventArgs e)
        {
            String output = "";
            // check selected history items first
            if(historyView.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in historyView.SelectedItems) //for each item
                {
                    WebsiteResponse response = await fetchWebsite(((HistoryItem)item.Tag).URL); // get corresponding URL with history item and query that
                    output += $"{response.responseCode} {response.bytes} {response.url}\r\n"; ; // add to output

                }
                htmlTextbox.Text = output; // print output and return
                return;
            }
            if (String.Equals(urlTextBox.Text, "")) //otherwise, if no selected items but url is empty
            {
                titleTextbox.Text = "<ERROR> Enter a valid bulk file name <ERROR>"; // inform user
                return;
            }
            List<string> urls = getBulkDownloads(urlTextBox.Text); // get bulk downloads from file path
            if (urls == null) return;
            foreach(string url in urls)
            {
                WebsiteResponse response = await fetchWebsite(url); //like before, request each one
                output += $"{response.responseCode} {response.bytes} {response.url}\r\n"; // and add to output
            }
            htmlTextbox.Text = output;
        }


        // helper method to get title from website body
        public static String GetTitle(string htmlBody)
        {
            string ret = "";
            
            // regex pattern to match titles (with parameters in title tag)
            string pattern = @"<title[^>]*>([\s\S]*?)<\/title>";
            Match match = Regex.Match(htmlBody, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ret = match.Groups[1].Value;
            }
            return ret;
        }

        // helper method to extract domain from website URL
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

        // query method, will either update a cache if one is provided or just outwrite query and add to history
        private async void queryURL(string url, HistoryItem? cacheToUpdate)
        {
            try
            {
                // get website
                using HttpResponseMessage response = await client.GetAsync(url);

                // set GUI accordingly
                urlTextBox.Text = url;
                codeTextbox.Text = "" + ((int)response.StatusCode) + " - " + response.StatusCode.ToString(); //TODO: Use string formatting to make this nicer
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                string title = GetTitle(responseBody).Trim();
                htmlTextbox.Text = responseBody.Trim();
                titleTextbox.Text = title;
                currentPage = new FavouriteItem(url, title);

                if (cacheToUpdate != null) // if we have a cache to update, update it and then we're done
                {
                    cacheToUpdate.cacheHTML(responseBody);
                    return;
                }

                // if no cache, we need to add to history etc
                string domain = getDomain(url) ?? url;
                HistoryItem newItem = new HistoryItem(url, domain);

                // add to listview
                historyView.Items.Add(new ListViewItem(newItem.guiName) { Tag = newItem });
                // Add to logical history
                historyHandler.addToHistory(newItem);
            } 
            // Error handling
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
   
        // helper (more condensed) query method
        private async Task<WebsiteResponse> fetchWebsite(string url)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);

                //read response body
                string responseBody = await response.Content.ReadAsStringAsync();

                //create struct
                return new WebsiteResponse((int)response.StatusCode, response.Content.Headers.ContentLength ?? 0, url, responseBody);
            }
            catch (Exception ex) //if something went wrong, return 'empty' struct
            {
                titleTextbox.Text = "<ERROR> HTTPException <ERROR>";
                return new WebsiteResponse(0, 0, url, "");
            }
        }

        // helper method to retrieve urls from specified file path (reletive or absolute)
        private List<string>? getBulkDownloads(string fileName)
        {
            string fileInternal = Path.Combine(APP_DIR, fileName); //get internal path
            bool internalExists = false, absoluteExists = false; 
            if (File.Exists(fileInternal)) { internalExists = true;  } //check if file exists interally or absolutely
            else if(File.Exists(fileName)) { absoluteExists = true; }
            if(!absoluteExists && !internalExists) //if neither, report to user and return null
            {
                titleTextbox.Text = "<ERROR> File does not exist <ERROR>";
                return null;
            }
            string filePath = (absoluteExists) ? fileName : fileInternal; //check WHICH of the two exists (with bias towards absolute)

            using (StreamReader reader = new StreamReader(filePath)) //read file (as seen in old historyHandler/favouriteshandler)
            {
                List<string> urlsFromFile = new List<string>();
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    urlsFromFile.Add(line);
                }

                return urlsFromFile;
            }
        }
    }

}
