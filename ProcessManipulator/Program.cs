using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessDemo
{
    class Program
    {
        static void StartProcess()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("FireFox.exe", "www.google.com");
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                Process fireFox = Process.Start(psi);
                Console.WriteLine("Press 'Enter to Kill'");
                Console.ReadLine();
                fireFox.Kill();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AllRunningProcesses()
        {
            try
            {
                var AllProc = from proc in Process.GetProcesses(".") where proc.Responding==true orderby proc.ProcessName select proc;
                foreach (Process p in AllProc)
                {
                    Console.WriteLine(p);
                    Console.WriteLine($"PID:{p.Id} ==>{p.ProcessName}");
                    if (p.ProcessName == "ProcessDemo")
                    {
                        Console.WriteLine("----------------Modules---------------------");
                        ProcessModuleById(p.Id);
                        Console.WriteLine("--------------------------------------------");
                    }
                }
                Console.WriteLine("Total: " + AllProc.Count());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void ProcessModuleById(int pid)
        {
            Process proc = Process.GetProcessById(pid);
            ProcessModuleCollection modules = proc.Modules;
            foreach(ProcessModule module in modules)
            {
                Console.WriteLine($"Module Name: {module.ModuleName}");
            }
        }
        static void ProcessByID(int id)
        {
            Process proc = Process.GetProcessById(id);
            foreach(ProcessThread pt in proc.Threads)
            {
                Console.WriteLine($"Id:{pt.Id}\nStart Time: {pt.StartTime}\nPriority :{pt.PriorityLevel}");
            }
        }
        static void Main(string[] args)
        {
            AllRunningProcesses();
            //ProcessByID(8552);
            //ProcessModuleById(29120);
            //StartProcess();

        }
    }
}
