using System;
using System.Net;

namespace LAB4_Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            //Khởi tạo 1 WebClient
            WebClient myClient = new WebClient();
            //Sử dụng phương thức OpenRead để đọc nội dung trang web vào một Stream
            Stream response = myClient.OpenRead(textURL.Text);
            //Tải file HTML về đường dẫn ghi trong textPath
            myClient.DownloadFile(textURL.Text, textPath.Text);
            //Mở Stream để đọc
            StreamReader reader = new StreamReader(response);
            //Đọc content
            String content = reader.ReadToEnd();
            //hiển thị content lên richTextBox1
            richTextBox1.Text = content;
        }
    }
}