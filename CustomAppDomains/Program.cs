using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomAppDomains
{
    class Program
    {
        static void ListAppDomainsAssemblies(AppDomain ad)
        {
            
            Console.WriteLine($"Name : {ad.FriendlyName}\nID: {ad.Id}\nIs default ?{ad.IsDefaultAppDomain()}\nBase Dir: {ad.BaseDirectory}");
            Console.WriteLine(".............Assemblies.............");
            //Assembly[] asm = ad.GetAssemblies();
            IEnumerable<Assembly> asm2 = from assemblies in ad.GetAssemblies() select assemblies;
            foreach (Assembly a in asm2)
            {
                Console.WriteLine(a);
                Console.WriteLine("...........................");
            }
            Console.WriteLine("-------------------------------");
        }
        static void NewAppDomain()
        {
            AppDomain ad = AppDomain.CreateDomain("NewAppDomain");
            ad.DomainUnload += (o, s) => Console.WriteLine("NewAppDomain Has been Unloaded");
            Assembly a = ad.Load("Test");
            ListAppDomainsAssemblies(ad);
            //ad.ExecuteAssembly();
            AppDomain.Unload(ad);
        }
        static void Main(string[] args)
        {
            ListAppDomainsAssemblies(AppDomain.CurrentDomain);
            Console.WriteLine("Created domain");
            NewAppDomain();
            Console.ReadLine();
        }
    }
}
