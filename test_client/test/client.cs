using System.Net;
using System.Net.Sockets;
using Client;
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
        public static String ipServer="";
        public client()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            btConnect.Enabled = false;
            Form formServer = new ConnectToServer();
    
            if(formServer.ShowDialog() == DialogResult.Cancel)
            {
                if(ipServer == "")
                {
                    MessageBox.Show("Enter server IP address!");
                    throw new Exception("Enter server IP address!");
                }
                client_server = new TcpClient();
                try
                {
                    client_server.Connect(IPAddress.Parse(ipServer), 51000);
                    swSender = new StreamWriter(client_server.GetStream());
                    receiver = new Thread(new ThreadStart(startClient));
                    receiver.Start();

                    MessageBox.Show("connect successfully");
                    messageCurrent.Text = "Connecting...";
                    btDisconnect.Enabled = true;
                    btConnect.Enabled = false;



                }
                catch (Exception)
                {
                    client_server.Close();
                    MessageBox.Show("connect unsuccessfully");
                    btConnect.Enabled = true;
                    btDisconnect.Enabled = false;
                    btSend.Enabled = false;

                }
            }
           
        }

        void startClient()
        {
            string fileName, fileSize;
            nwStream = client_server.GetStream();
            srReceiver = new StreamReader(nwStream);

            try
                {
                    while (client_server.Connected)
                    {
                   
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

                        using (var output = File.Create(savePath))
                        {
                            // read the file divided by 1KB
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
            tbPath.Text = "";
          
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                savePath = fbd.SelectedPath;
                tbSavePath.Text = savePath;
                savePath = savePath.Replace("\\","\\\\");
                btSend.Enabled = true;
            }
        }


        private void client_FormClosing(object sender, EventArgs e)
        {
            if (client_server.Connected)
            {
                swSender.WriteLine("EXIT");
                swSender.Flush();
                swSender.Close();
                client_server.Close();
                nwStream.Close();
                srReceiver.Close();
            }
          
        }
    }
}