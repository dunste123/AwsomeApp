using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace AwsomeApp
{
    // An example program which uses a simple menu 
    // to communicate with the user
    class Program
    {
        // Stop controls the moment the application is halted (finished)
        private static bool Stop = false;

        static void Main(string[] args)
        {
            do
            {   // Writing the menu to the screen
                Console.Clear();
                Console.WriteLine("Main menu AwsomeApp\n");
                Console.WriteLine("F)iles");
                Console.WriteLine("H)elp");
                Console.WriteLine();
                Console.WriteLine("E)nd");
                // waiting for a character to be pressed on the keyboard (any char)
                char Input = Console.ReadKey().KeyChar;
                // counts the number of times a character is pressed in the menu
                Counter++;
                switch (Input) // only if a case is fullfilled the action will be taken.
                {
                    case 'F': ShowFiles(); break;
                    case 'H': ShowHelp();break;
                    case 'E': Stop = true;break;
                        // all other character trigger a error message to be displayed
                    default: Console.WriteLine("Enter A allowed Key, Please"); break;
                }
            }
            while (!Stop);
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
