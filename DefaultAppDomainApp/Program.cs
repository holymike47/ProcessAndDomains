using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DefaultAppDomainApp
{

    class Program
    {
        static void DefaultAppDomain()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine($"Name : {ad.FriendlyName}\nID: {ad.Id}\nIs default ?{ad.IsDefaultAppDomain()}\nBase Dir: {ad.BaseDirectory}");
            Console.WriteLine(".............Assemblies.............");
            //Assembly[] asm = ad.GetAssemblies();
            IEnumerable<Assembly> asm2 = from assemblies in ad.GetAssemblies() select assemblies;
            foreach(Assembly a in asm2)
            {
                Console.WriteLine(a);
            }

        }
        static void InitAppDomain()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            ad.AssemblyLoad += (o, s) => Console.WriteLine($"{s.LoadedAssembly.GetName().Name} has been loaded");
        }



        static void Main(string[] args)
        {
            InitAppDomain();
            DefaultAppDomain();
        }
    }
}
