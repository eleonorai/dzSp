using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzSp
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Enter rogram name (notepad):");
            string programName = Console.ReadLine();

            if (string.IsNullOrEmpty(programName))
                programName = "notepad.exe";

            Process childProcess = new Process();
            childProcess.StartInfo.FileName = programName;

            try
            {
                childProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error with starting process: " + ex.Message);
                return;
            }

            Console.WriteLine("Enter 1 - wait for ending process; 2 - forced ending process");
            string input = Console.ReadLine();

            if (input == "1")
            {
                childProcess.WaitForExit();
                Console.WriteLine("ending code: " + childProcess.ExitCode);
            }
            else if (input == "2")
            {
                try
                {
                    childProcess.Kill();
                    Console.WriteLine("process was forced ended");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error process ending: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("unkown command: " + input);
            }
        }
    }
}