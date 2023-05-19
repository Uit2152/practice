using System.Net.Http;
using System.Net.Http.Headers;

using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;
namespace LAB4_B2
{    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btPost_Click(object sender, EventArgs e)
        {
 //Khởi tạo request với địa chỉ URL nhập vào
            WebRequest request = WebRequest.Create(textURL.Text);
            
//Lấy dữ liệu POST từ form, sau đó convert sang mảng byte.
            String postData = textData.Text;
            var json = JsonSerializer.Serialize(postData);
            Byte[] data = Encoding.ASCII.GetBytes(postData);

//Thiết lập phương thức request
            request.Method = "POST";
//Thiết lập thuộc tính Content Type của WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
 //Thiết lập độ dài của nội dung trả về (Content Length) bởi WebRequest
            request.ContentLength = data.Length;

//Gửi dữ liệu lên địa chỉ URL tương ứng
//Tạo request stream bằng cách get request stream từ WebRequest
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
 //Khởi tạo response để nhận phản hồi từ server
            WebResponse response = request.GetResponse();
 //hiển thị trạng thái phản hồi lên richTextBox1
            richTextBox1.Text = ((HttpWebResponse)response).StatusDescription;
 //tạo stream chứa content mà server trả về
            Stream dataStream= response.GetResponseStream();
 //dùng StreamReader để mở stream ra
            StreamReader reader = new StreamReader(dataStream);
 //Đọc content
            String responseFromServer = reader.ReadToEnd();
 //kết thúc việc nhận phản hồi từ server
            response.Close();
 //hiển thị nội dung server phản hồi lên richTextBox1
            richTextBox1.Text += "\r\n"+responseFromServer;
        }
    }
}