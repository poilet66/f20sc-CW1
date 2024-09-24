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

namespace CW1_Try2
{
    public partial class Form1 : Form
    {

        HttpClient client;

        public Form1()
        {
            InitializeComponent();
            this.client = new HttpClient();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void onTextboxEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                TextBox box = (TextBox)sender;
                using HttpResponseMessage response = await client.GetAsync(box.Text);
                label2.Text = "" + ((int) response.StatusCode) + " - " + response.StatusCode.ToString(); //TODO: Use string formatting to make this nicer
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                label1.Text = responseBody;

            }
        }
    }
}
