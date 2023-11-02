using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
    public partial class Form1 : Form
    {
        private readonly TamperProofProcessor _tamperProofProcessor;
        private byte[] _aesKey;
        private Encryptor _encryptor;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            _tamperProofProcessor = new TamperProofProcessor();
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            _encryptor = new Encryptor();
        }

        private void client_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rekey
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            string newKey = Convert.ToBase64String(_aesKey);
            textBox4.AppendText("New key is: " + newKey);
            string message = "Rekey";
            Byte[] buffer = Encoding.Default.GetBytes(message);
            foreach (Socket client in clientSockets)
            {
                try
                {
                    client.Send(buffer);
                }
                catch
                {
                    textBox4.AppendText("There is a problem! Check the connection...\n");
                    terminating = true;
                    serverSocket.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int serverPort;
           
            if (Int32.TryParse(textBox3.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
               

                Thread acceptThread = new Thread(AcceptClient);
                acceptThread.Start();

                textBox4.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                textBox4.AppendText("Please check port number \n");
            }

        }
        private void AcceptClient()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    textBox4.AppendText("Client is connected.\n");

                    Thread receiveThread = new Thread(() => Receive(newClient));
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        textBox4.AppendText("The socket stopped working.\n");
                    }

                }
            }

        }
        private void Receive(Socket thisClient) 
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[128];
                    thisClient.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    if (incomingMessage == "Rekey")
                    {
                        _aesKey = _tamperProofProcessor.GetNewSessionKey();
                        string newKey = Convert.ToBase64String(_aesKey);
                        textBox4.AppendText("Get new session key after client's request: " + newKey + "\n");
                    }
                    else
                    {
                        string message = _encryptor.Decrypt(Encoding.Default.GetBytes(incomingMessage), _aesKey);
                        textBox4.AppendText("Server: " + message + "\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        textBox4.AppendText("A client has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //send message
            string message = textBox1.Text;
           
            if (message != "" && message.Length <= 64)
            {
                (byte[] IV, byte[] ctext) = _encryptor.Encrypt(_aesKey, message);
                Byte[] combined = new byte[IV.Length + ctext.Length];

                Array.Copy(IV, combined, IV.Length);
                Array.Copy(ctext, 0, combined, IV.Length, ctext.Length);

                foreach (Socket client in clientSockets)
                {
                    try
                    {
                        client.Send(combined);
                    }
                    catch
                    {
                        textBox4.AppendText("There is a problem! Check the connection...\n");
                        terminating = true;
                        serverSocket.Close();
                    }

                }
            }

        }
    }
}
