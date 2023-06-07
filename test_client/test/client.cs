using System.Net;
using System.Net.Sockets;
using Client;
using System.Runtime.Serialization.Formatters.Binary;

using System.Reflection;
using System.Runtime.Serialization;

namespace test
{
    public partial class client : Form
    {
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private NetworkStream nwStream;
        private TcpClient client_server;
        private Thread receiver;
        private String savePath;
        public static String ipServer = "";
        public client()
        {
            InitializeComponent();
        }

        //nút kết nối với server
        private void btConnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            Form formServer = new ConnectToServer();
//Hiển thị form nhập server IP address
            if (formServer.ShowDialog() == DialogResult.Cancel)
            {
                if (ipServer == "")
                {
                    MessageBox.Show("Enter server IP address!");
                    throw new Exception("Enter server IP address!");
                }
//thực hiện kết nối tới server có IP đã nhập
                client_server = new TcpClient();
                try
                {
                    client_server.Connect(IPAddress.Parse(ipServer), 51000);
                    swSender = new StreamWriter(client_server.GetStream());

////Tạo treeview                  
//                    while(!PopulateTreeView())
//                    {

//                    }


//Tạo luồng nhận thông điệp
                     
//sự kiện click chuột vào 1 node của tree view
 //                   this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);

                        MessageBox.Show("connect successfully");
                        messageCurrent.Text = "Connecting...";
                        btDisconnect.Enabled = true;
                        btConnect.Enabled = false;

                    receiver = new Thread(new ThreadStart(startClient));
                    receiver.Start();
                }
                catch (Exception)
                {
//đóng kết nối nếu có lỗi xảy ra
                    client_server.Close();
                    MessageBox.Show("connect unsuccessfully");
                    btConnect.Enabled = true;
                    btDisconnect.Enabled = false;
                    btSend.Enabled = false;

                }
            }

        }
// bắt đầu luồng nhận thông điệp
        void startClient()
        {
            string fileName, fileSize;
            nwStream = client_server.GetStream();
            nwStream.Flush();
            srReceiver = new StreamReader(nwStream);

            try
            {
                while (client_server.Connected)
                {
//Đọc thông tin(kích thước, tên) của file mà client muốn server gửi
                    String fileInfo = srReceiver.ReadLine();

                    messageCurrent.Invoke(new MethodInvoker(delegate ()
                    {
                        messageCurrent.Text = "Reading file infomation...";
                    }
                    ));

                    String[] mess = fileInfo.Split('#');

                    fileName = mess[1];
                    fileSize = mess[2];
                    savePath += "\\" + fileName.Trim();

//thực hiện nhận và lưu file mà server gửi
                    using (var output = File.Create(savePath))
                    {

                        var buffer = new byte[Int32.Parse(fileSize)];

                        nwStream.Read(buffer, 0, buffer.Length);

                        output.Write(buffer, 0, Int32.Parse(fileSize));

                        //MessageBox.Show("ok");

                        fileName = "";
                        fileSize = "";
                        nwStream.Flush();

                        messageCurrent.Invoke(new MethodInvoker(delegate ()
                        {
                            messageCurrent.Text = "Read file.";
                        }
                  ));

                    }
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);

            }

        }

//thực hiện ngắt kết nối client-server
        private void btDisconnect_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            swSender.WriteLine("EXIT");
            swSender.Flush();
            swSender.Close();
            client_server.Close();
            nwStream.Close();
            srReceiver.Close();

            MessageBox.Show("Disconnect successfully");
            btConnect.Enabled = true;
            btDisconnect.Enabled = false;
            btSend.Enabled = false;
        }
//Gửi đường dẫn của file mà client muốn tải về
        private void btSend_Click(object sender, EventArgs e)
        {

            if (tbPath.Text != "" && tbSavePath.Text != "")
            {
                swSender.WriteLine(tbPath.Text.ToString().Trim());
                swSender.Flush();

            }
            else
            {
                btSend.Enabled = false;
            }
         

        }

//chọn nơi lưu file 
        private void btSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                savePath = fbd.SelectedPath;
                tbSavePath.Text = savePath;
                savePath = savePath.Replace("\\", "\\\\");
                btSend.Enabled = true;
            }
        }

//xử lý sự kiện đóng form khi vẫn còn giữ kết nối server-client
        private void client_FormClosing(object sender, EventArgs e)
        {
            if (client_server.Connected)
            {
                swSender.WriteLine("EXIT");
                swSender.Flush();
                swSender.Close();
                client_server.Close();
              
                srReceiver.Close();
            }
        }


// Tạo fileTree     
        private bool PopulateTreeView()
        {
            TreeNode receivedData;
//nhận treenode từ server
            using (MemoryStream ms = new MemoryStream())
            {
                NetworkStream Stream;
                Stream= client_server.GetStream();
            
                byte[] buffer = new byte[10240*1024];
               int i = Stream.Read(buffer, 0, buffer.Length);
            
                ms.Write(buffer, 0, buffer.Length);

                ms.Seek(0, SeekOrigin.Begin);
                BinaryFormatter bf = new BinaryFormatter();

              receivedData = (TreeNode)bf.Deserialize(ms);
                Stream.Flush();
               

            }
//tạo treeview từ treenode mà server gửi
            TreeNode rootNode;
            rootNode = receivedData;
            treeView1.Nodes.Add(rootNode);
           
            return true;
        }
           


//Xử lý sự kiện click chuột vào 1 node của treeview
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
 // hiển thị fullPath của file lên tbPath
            if (e.Node.ImageKey == "file")
            tbPath.Text = e.Node.Parent.Name + "\\" + e.Node.Text;

        }

      
    }
}