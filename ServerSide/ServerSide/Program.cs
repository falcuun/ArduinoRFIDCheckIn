using System;
using System.IO.Ports;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort sp = new SerialPort();
            string[] available_ports = SerialPort.GetPortNames();
            foreach(string port in available_ports) {
                Console.WriteLine(port);
            }

            Console.ReadLine();
        }
    }
}
