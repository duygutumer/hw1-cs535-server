using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hw1_cs535_server_main;

namespace Server
{
    public partial class Form1 : Form
    {
        private readonly TamperProofProcessor _tamperProofProcessor;
        private byte[] _aesKey;

        private ServerLogic _serverLogic;


        public Form1()
        {
            InitializeComponent();

            _tamperProofProcessor = new TamperProofProcessor(100);
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
            _serverLogic = new ServerLogic();
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

        private void rekey_button_Click(object sender, EventArgs e)
        {
            _aesKey = _tamperProofProcessor.GetNewSessionKey();

            // TODO:
            // send message to rekey for client
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            int serverPort;
            if (Int32.TryParse(portText.Text, out serverPort))
            {
                string message = _serverLogic.Listen(serverPort, messageBox);
                messageBox.AppendText(message);
            }
            else
            {
                messageBox.AppendText("Could not start listening port " + portText.Text + "!\n");
                messageBox.AppendText("Please check port!\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
