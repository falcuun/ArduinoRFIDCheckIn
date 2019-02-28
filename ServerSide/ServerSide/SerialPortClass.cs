using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace ServerSide
{
    partial class SerialPortClass
    {
        private SerialPort sp;
        private Database db;


        public void init()
        {
            sp = new SerialPort(Get_Port_Name(), Get_Baudrate(), Parity.None, 8, StopBits.One);
            db = new Database();
            sp.DtrEnable = true;
            sp.DataReceived += serialComms_DataReceived;
            sp.Open();
            db.init();
            Get_Command_Line_Command();
        }

        private void Get_Command_Line_Command()
        {
            string command = Console.ReadLine().ToUpper();

            switch (command)
            {
                case "Q":
                case "QUIT": Environment.Exit(0); break ;
                default: Get_Command_Line_Command(); break;
            }
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

        private void Get_Serial_Reading(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            DB_Insert(text);
        }

        private void DB_Insert(string query_value)
        {
            db.Insert_Query(query_value, "NAME");
        }

        void serialComms_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = sp.ReadLine();
            Get_Serial_Reading(message);
        }
    }
}

