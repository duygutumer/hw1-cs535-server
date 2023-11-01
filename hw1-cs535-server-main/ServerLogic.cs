using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw1_cs535_server_main
{
    internal class ServerLogic
    {
        private Socket _serverSocket;
        private Socket _clientSocket;

        private bool _binded = false;
        private bool _connected = false;
        private bool _terminating = false;
        private bool _listening = false;

        int PacketSize = 512;

        public string Listen(int port, TextBox messageBox)
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
                if (!_binded)
                {
                    _serverSocket.Bind(endPoint);
                    _binded = true;
                }

                _serverSocket.Listen(3);
            }
            catch
            {
                return "Error occured while connecting to the Port!\n";
            }

            _listening = true;
            Thread acceptClientThread = new Thread((object messageBox) => AcceptClient(messageBox));
            acceptClientThread.Start();

            return "Server is listening for connections.\n";
        }

        public bool AcceptClient(object messageBox)
        {
            TextBox textBox  = (TextBox) messageBox;

            while (_listening)
            {
                try
                {
                    _clientSocket = _serverSocket.Accept();

                    Thread receiveMsgThread = new Thread((textBox) => ReceiveMsg(textBox));
                    receiveMsgThread.Start();
                }
                catch
                {
                    if (_terminating)
                    {
                        _listening = false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ReceiveMsg(object messageBox)
        {
            TextBox textBox = (TextBox) messageBox;

            _connected = true;
            while (_connected && !_terminating)
            {
                Byte[] buffer = new byte[PacketSize];
                _clientSocket.Receive(buffer);
                var encryptedMessage = Encoding.Default.GetString(buffer).Trim('\0');

                // TODO:
                // decrypt message

                textBox.AppendText(encryptedMessage);
            }
        }
    }
}
