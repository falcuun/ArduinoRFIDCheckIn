using System;
using System.Threading.Tasks;

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
