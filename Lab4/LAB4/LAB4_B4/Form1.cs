using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;

using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Text;
using HtmlAgilityPack;
namespace LAB4_B4
{
    public partial class Form1 : Form
    {
        public static string url;
        public Form1()
        {
            InitializeComponent();
            //thiết lập lại kích thước cho From1
            this.Resize += new System.EventHandler(this.Form_Resize);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //thiết lập kích thước cho webView (màn hình webbrowser)
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
        }
        private void bt_Click(object sender, EventArgs e)
        {
            //Điều kiện để webView hoạt động
            if (webView != null && webView.CoreWebView2 != null)
            {
                try
                {
                    webView.CoreWebView2.Navigate(textBox.Text);
                }
                catch (ArgumentException exit)
                {
                   
                }
            }
        }
        private void sourceBt_Click(object sender, EventArgs e)
        {
            //lấy URL lưu trữ vào biến url (url là biến dùng chung cho cả 2 form: sourceForm và Form1)
            url = textBox.Text;
            Form sourceForm = new sourceForm();
            //mở form sourceForm
            sourceForm.Show();
        }
        private void downloadsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };
            //Load trang web, nạp html vào document
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(textBox.Text);

            // //Chọn nơi lưu file và tên file sau khi lưu
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            //Tạo file .txt chứa HTML của wed
            FileStream fs = new FileStream(sfd.FileName, FileMode.CreateNew); 
           StreamWriter sw= new StreamWriter(fs) ;
            //lưu file html
            document.Save(sw);
        }
    }
}