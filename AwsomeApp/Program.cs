using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;
using System.IO;

namespace AesomeApp
{
    // An example program which uses a simple menu 
    // to communicate with the user
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("Main menu AwsomeApp\n");

            //menu.AddItem("F)iles", 'F', () => ShowFiles());
            menu.AddItem("&Files", ShowFiles);
            //menu.AddItem("H)elp", 'H', () => ShowHelp());
            menu.AddItem("&Help", ShowHelp);
            //menu.AddItem("E)nd", 'E', () => EndProgram());
            menu.AddItem("&End", EndProgram);

            menu.Run();
        }

        private static void EndProgram()
        {
            Environment.Exit(0);
        }

        // The application consists of a number of actions which work on 
        // common data which is in the application objects scope
        // as an example this variable
        private static int Counter = 0;
        // The action to be taken if an F (uppercase F) is pressed
        private static void ShowFiles()
        {
            // Shows current counter value
            Console.WriteLine("Counter = {0}", Counter); Console.WriteLine();
            // ask for the directorypath of which the file list should be displayed
            Console.WriteLine("Enter the full directory path to list the files:");
            Console.Write(">");
            string directory = Console.ReadLine().Trim();
            // if no path is entered the current path is shown.
            if (string.IsNullOrEmpty(directory)) directory = ".";
            try
            {
                // show the filenames of the given directory
                string[] files = Directory.GetFiles(directory);
                foreach(string f in files)
                {
                    Console.WriteLine("{0,50}", f); // orientate to the right insteat of the left
                }
            }
            catch
            {
                Console.WriteLine($"This directoryname '{directory}' causes an error!");
                // previous line and next line do the same thing!!!!
                // Console.WriteLine("This directoryname '{0}' causes an error!",directory);
            }
            // Wait for the enter key otherwise the information in the window is lost (and perhaps not visible)
            Console.Write("Press enter to continue..");
            Console.ReadLine();
        }

        private static void ShowHelp()
        {
            // Shows current counter value
            Console.WriteLine("Counter = {0}", Counter);Console.WriteLine();

            Console.WriteLine("Help text comes here.....");
            Console.Write("Press enter to continue..");
            Console.ReadLine();
        }
    }
}
