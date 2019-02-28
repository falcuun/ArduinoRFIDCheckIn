using System;
using System.IO.Ports;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.init();
            db.Insert_Query("20 20 20 20", "NAME");
            db.Delete_Query();
            SerialPortClass spc = new SerialPortClass();
            spc.init();

        }    
    }
}
