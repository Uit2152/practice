using System;
using System.Net;
namespace LAB4_B1
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void btGet_Click(object sender, EventArgs e)
        {
            //hiển thị nội dung html lên richTextBox1
            richTextBox1.Text = getHTML(textURL.Text);
        }
    }
}