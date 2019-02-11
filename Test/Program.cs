using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void MyPrint(string msg) => Console.WriteLine(msg);
        static void Main(string[] args)
        {
            Console.WriteLine("Test assembly");
            MyPrint("Thanks HolyMike");
        }
    }
}
