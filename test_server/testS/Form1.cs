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
        private NetworkStream nwStream;
        private Thread serverThread;
        private TcpListener listener;
        private TcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void btListen_Click(object sender, EventArgs e)
        {
            Int32 port = 51000;
           
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();

            messageCurrent.Text = "Listening...";
            btListen.Enabled = false;

        }

        void StartServer()
        {
            client = listener.AcceptTcpClient();
            
            messageCurrent.Invoke(new MethodInvoker(delegate ()
            {
                messageCurrent.Text = "Connecting...";
            }
            ));
           
            listener.Stop();

            bool flag = true;
            while(flag)
            {
                DirectoryInfo info = new DirectoryInfo("C:\\Users\\ADMIN\\Music");
                TreeNode rootNode = PopulateTreeView(info);
                
                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();
               
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, rootNode);
                    byte[] bytes = ms.ToArray();
                    ns.Write(bytes, 0, bytes.Length);
                }
                ns.Close();
                flag = false;
            }


            try
            {
                while (client.Connected)
                {
                    nwStream = client.GetStream();
                    var srClient = new StreamReader(nwStream);
                   

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
                   
                    FileInfo fileInfo = new FileInfo(filePath);
                    long fileSize = fileInfo.Length;
                    String fileName = fileInfo.Name;
                    String infoData = ("#"+fileName + "#" + fileSize.ToString()); 


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
                   
                    var swClient = new StreamWriter(nwStream);
                    swClient.WriteLine(infoData);
                    swClient.Flush();


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
                MessageBox.Show(ex.Message);

                if (client != null)

                {
                    listener.Stop();
                    client.Close();
                    btListen.Enabled = true;
                }
              
            }

        }


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


/// <summary>
/// ///////////////////////////////////////////////////
/// </summary>
        private TreeNode PopulateTreeView(DirectoryInfo info)
        {
            TreeNode rootNode= new TreeNode(info.Name) ;

            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                rootNode.Name = "C:\\Users\\ADMIN\\Music";
                GetDirectories(info.GetDirectories(), rootNode);
               
            }
            return rootNode;
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
    }
}