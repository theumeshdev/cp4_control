using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CP4Pro
{
    internal class TCPClientControl
    {

        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private const int Port = 23; // Default TCP port for Crestron CP4
     

        public TCPClientControl()
        {
            tcpClient = new TcpClient();
        }


        public bool Connect(string ipAddress)
        {
            try
            {
                tcpClient.Connect(ipAddress, Port);
                networkStream = tcpClient.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to CP4: " + ex.Message);
                return false;
            }
        }

        public void SendCommand(string command)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(command);
                networkStream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent command: {command}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending command: " + ex.Message);
            }
        }

        // Receive response from the CP4
        public string ReceiveResponse()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, bytesRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving response: " + ex.Message);
                return string.Empty;
            }
        }



           public void Disconnect()
        {
            try
            {
                networkStream.Close();
                tcpClient.Close();
                Console.WriteLine("Disconnected from CP4.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error disconnecting from CP4: " + ex.Message);
            }
        }



    }
}
