using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP4Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Starting Crestron CP4 Control...");

                // Instantiate the TCP client control class
                TCPClientControl tcpControl = new TCPClientControl();

                // CP4 IP address (change to your CP4's IP)
                string cp4IpAddress = "192.168.1.100";

                // Connect to the CP4
                if (tcpControl.Connect(cp4IpAddress))
                {
                    Console.WriteLine("Connected to CP4.");

                    // Send a sample command to control a relay (e.g., turn on relay 1)
                    tcpControl.SendCommand("relay1:on");

                    // Receive and display the response from the CP4
                    string response = tcpControl.ReceiveResponse();
                    Console.WriteLine("Response from CP4: " + response);

                    // Disconnect after the operation
                    tcpControl.Disconnect();
                }
                else
                {
                    Console.WriteLine("Failed to connect to CP4.");
                }

                Console.WriteLine("Program complete. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
