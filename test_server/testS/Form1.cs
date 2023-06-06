using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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
            
            nwStream.Close();
       
        }
    }
}