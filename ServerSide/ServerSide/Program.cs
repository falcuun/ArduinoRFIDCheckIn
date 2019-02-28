using System;
using System.IO.Ports;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPortClass spc = new SerialPortClass();
            spc.init();
        }    
    }
}
