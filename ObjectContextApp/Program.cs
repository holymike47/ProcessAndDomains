using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace ObjectContextApp
{
    class Car1
    {
        public Car1()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine(this +" is in Context: "+ctx.ContextID);
            foreach(IContextProperty prop in ctx.ContextProperties)
            {
                Console.WriteLine(prop);
                Console.WriteLine(prop.Name);
                
            }
            Console.WriteLine("=======================================");
        }
    }
    [Synchronization]
    class Car2 : ContextBoundObject
    {
        public Car2()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine(this + " is in Context: " + ctx.ContextID);
            foreach (IContextProperty prop in ctx.ContextProperties)
            {
                Console.WriteLine(prop);
                Console.WriteLine(prop.Name);
                
            }
            Console.WriteLine("=======================================");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Car1();
            new Car2();
        }
    }
}
