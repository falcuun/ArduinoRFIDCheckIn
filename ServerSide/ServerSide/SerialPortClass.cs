using System;
using System.IO.Ports;

namespace ServerSide
{
    partial class SerialPortClass
    {
        private SerialPort sp;

        public void init()
        {
            sp = new SerialPort(Get_Port_Name(), Get_Baudrate(), Parity.None, 8, StopBits.One);
            sp.DtrEnable = true;
            sp.DataReceived += serialComms_DataReceived;
            sp.Open();
            while (sp.IsOpen) ;
        }

        private string Get_Port_Name()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string[] available_ports = SerialPort.GetPortNames();
            string port_name;
            int index = 0;

            Console.WriteLine("Available Ports: ");

            foreach (string port in available_ports)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(index + ": ");
                Console.WriteLine(port);
                index++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Choose The Port By Index: ");

            try
            {
                int choice = Console.ReadLine()[0] - '0';
                port_name = available_ports[choice];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Port Name is: " + port_name);
                return port_name;
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input, Try Again!");
                Console.WriteLine();
                return Get_Port_Name();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input, Try Again!");
                Console.WriteLine();
                return Get_Port_Name();
            }
        }

        private int Get_Baudrate()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter The Baud Rate: ");
            int baud = 0;
            string baudrate = Console.ReadLine();
            try
            {
                baud = int.Parse(baudrate);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Baudrate is: " + baud);
                return baud;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input, Try Again!");
                Console.WriteLine();
                return Get_Baudrate();
            }
        }

        public void Get_Serial_Reading(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }

        void serialComms_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = sp.ReadLine();
            Get_Serial_Reading(message);
        }
    }
}

