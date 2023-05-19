using System;
using System.Net;

namespace LAB4_B4
{
    public partial class sourceForm : Form
    {
        public sourceForm()
        {
            InitializeComponent();
        }
        private string getHTML(string strURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(strURL);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Close the response.
            response.Close();
            return responseFromServer;
        }
        private void sourceForm_Load(object sender, EventArgs e)
        {
            sourceRichTextBox.Text = getHTML(Form1.url);
        }
    }
}
