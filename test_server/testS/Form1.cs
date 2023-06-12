using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace testS
{
    public partial class Form1 : Form
    {
        private String downloadPath="";

        private NetworkStream nwStream;
        private Thread serverThread;
        private TcpListener listener;
        private TcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

//Nút bắt đầu quá trình lắng nghe của server
        private void btListen_Click(object sender, EventArgs e)
        {
            Int32 port = 51000;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();

    //Thông báo quá trình xử lý của server
            messageCurrent.Text = "Listening...";
            btListen.Enabled = false;

        }

//Luồng thực hiện quá trình trao đổi giữa server và client
        void StartServer()
        {
            client = listener.AcceptTcpClient();
            nwStream = client.GetStream();
            var swClient = new StreamWriter(nwStream);
            var srClient = new StreamReader(nwStream);

            messageCurrent.Invoke(new MethodInvoker(delegate ()
            {
                messageCurrent.Text = "Connecting...";
            }
            ));

            listener.Stop();

            if (downloadPath != "")
            {
                swClient.WriteLine("Tree");
                swClient.Flush();
                sendFileTree();
            }
            else
            {
                swClient.WriteLine("NotTree");
                
            }
            swClient.Flush();
            nwStream.Flush();

            try
            {
        //thực hiện nhận yêu cầu từ client
                while (client.Connected)
                {
                    String filePath = srClient.ReadLine();
                    if (filePath == "EXIT")
                    {
                        messageCurrent.Invoke(new MethodInvoker(delegate ()
                        {
                            messageCurrent.Text = "Closing connection...";
                        }
                         ));

                        closeConnect();
                        btListen.Enabled = true;
                        break;
                    }

                    messageCurrent.Invoke(new MethodInvoker(delegate ()
                    {
                        messageCurrent.Text = "Reading filePath...";
                    }
                    ));
            //Lấy thông tin(kích thước và tên) của file mà server yêu cầu                
                    FileInfo fileInfo = new FileInfo(filePath);
                    long fileSize = fileInfo.Length;
                    String fileName = fileInfo.Name;
                    String infoData = ("|" + fileName + "|" + fileSize.ToString());

            //hiển thị fullPath của file mà client yêu cầu lên bảng Notice_board của server
                    notice_board.Invoke(new MethodInvoker(delegate ()
                    {
                        notice_board.Text += "\r\nFrom client: " + filePath;
                    }
                   ));

                    messageCurrent.Invoke(new MethodInvoker(delegate ()
                    {
                        messageCurrent.Text = "Sending file...";
                    }
                    ));
          
            //Gửi thông tin(kích thước file và tên file) của file mà client yêu cầu cho server                
            //var swClient = new StreamWriter(nwStream);

                    swClient.WriteLine(infoData);
                    swClient.Flush();

            //Gửi file mà client yêu cầu cho server (không gửi dc file zip)
   
                    FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    file.CopyTo(nwStream);
                    byte[] package = new byte[file.Length];
                    nwStream.Write(package, 0, ((int)file.Length));

                    nwStream.Flush();
                    swClient.Flush();

                    messageCurrent.Invoke(new MethodInvoker(delegate ()
                    {
                        messageCurrent.Text = "File was sent.";
                    }
                    ));
                }
            }
            catch (Exception ex)
            {
        //Thông báo lỗi xảy ra
                MessageBox.Show(ex.Message);
        //Đóng hết kết nối nếu đã thực hiện thành công việc kết nối server-client
                if (client != null)
                {
                    listener.Stop();
                    client.Close();
                   btListen.Invoke(new MethodInvoker(delegate ()
                    {
                        btListen.Enabled = true;
                    }
                    ));  
                }

            }

        }

//Phương thức thực hiện đóng kết nối
        void closeConnect()
        {
            listener.Stop();
            client.Close();

            btListen.Invoke(new MethodInvoker(delegate ()
            {
                btListen.Enabled = true;
            }
            ));
            messageCurrent.Invoke(new MethodInvoker(delegate ()
            {
                messageCurrent.Text = "Close connection";
            }
            ));
            nwStream.Close();

        }

//Phương thức gửi file tree
        private void sendFileTree()
        {

    //server sẽ gửi file tree của 1 thư mục mà server chọn cho client
            String[] folderPath = downloadPath.Split("||");
            DirectoryInfo info = new DirectoryInfo(folderPath[0]);
    //Tạo file tree với rootNode là thư mục đã chọn
            TreeNode rootNode = new TreeNode("Root");
            rootNode.Nodes.Add(PopulateTreeView(info));

            for (int i = 1; i < folderPath.Length-1; i++)
            {
                rootNode.Nodes.Add(PopulateTreeView(new DirectoryInfo(folderPath[i])));
            }

            NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();
    //gửi file tree cho client              
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, rootNode);
                    byte[] bytes = ms.ToArray();

                    ns.Write(bytes, 0, bytes.Length);
                }
                ns.Flush();
               
           
        }
//Phương thức tạo fileTree 
        private TreeNode PopulateTreeView(DirectoryInfo info)
        {
            TreeNode rootNode = new TreeNode(info.Name);

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name,0,0);
                rootNode.Tag = info;
        ////////Xem lại chỗ này  -> chình lại cho đường dẫn file bên client  đúng
                rootNode.Name = info.FullName;
                rootNode.ImageKey = "folder";
                getFile(info.GetDirectories(), rootNode);
            }
            return rootNode;
        }


//Tạo các node đại diện cho file có trong thư mục được đại diện bởi rootnode của fileTree
        private void getFile(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo nodeDirInfo = (DirectoryInfo)nodeToAddTo.Tag;

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                aNode = new TreeNode(file.Name, 1, 1);

                aNode.ImageKey = "file";

                nodeToAddTo.Nodes.Add(aNode);
            }
        }

//chọn thư mục để tạo fileTree rồi sau đó gửi cho client
        private void btPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                downloadPath +=   fbd.SelectedPath +"||";
                tbPath.Text += fbd.SelectedPath +"\r\n";
               // downloadPath = downloadPath.Replace("\\", "\\\\");

            }
        }
    }
}