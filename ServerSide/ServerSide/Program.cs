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
            int index = 0;

            Console.WriteLine("Available Ports: ");

            foreach(string port in available_ports) {
                Console.Write(index + ": ");
                Console.WriteLine(port);
                index++;
            }

            Console.Write("Choose The Port By Index: ");
            int choice = Console.ReadLine()[0] - '0';

            Console.WriteLine("You picked: " + available_ports[choice] + " Port");
            Console.ReadLine();
        }
    }
}
