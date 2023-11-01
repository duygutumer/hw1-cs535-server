using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Form1()
        {
            InitializeComponent();

            _tamperProofProcessor = new TamperProofProcessor(100);
            _aesKey = _tamperProofProcessor.GetNewSessionKey();
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
            messageBox.Text = Encoding.UTF8.GetString(_aesKey);
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
