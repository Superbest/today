using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Today
{
    class Program
    {
        static Dictionary<string, string> date_formats = new Dictionary<string, string>();

        [STAThread]
        static void Main(string[] args)
        {
            date_formats["-iso"] = "yyyy-MM-dd";
            date_formats["-us"] = "M/d/yyyy";

            if (args.Count() != 1 || !date_formats.ContainsKey(args[0]))
            {
#if DEBUG
                Console.WriteLine("Arguments given:\n\t" + string.Join("\n\t", args) + "\n\n   -----\n"); 
#endif
                Print_usage_info();
            }
            else
            {
                var arg = args[0];
                if (!date_formats.ContainsKey(arg)) Print_usage_info();

                Date_to_clipboard(arg);
            }
        }

        /// <summary>
        /// Sends the current date to the clipboard.
        /// </summary>
        /// <param name="arg"></param>
        private static void Date_to_clipboard(string arg)
        {
            var today = "";
            var format = date_formats[arg];
            today = DateTime.Now.ToString(format);

            Clipboard.SetText(today);
        }

        /// <summary>
        /// Prints usage information (mainly for providing a helpful response when user provides a bad argument).
        /// </summary>
        private static void Print_usage_info()
        {
            Console.WriteLine(
                "Invalid arguments.\n\nThis program copies today's date in a specified format to the Windows clipboard.\n\nPlease use exactly one of the following arguments:");
            
            // Prints all the currently supported formats
            foreach (var kvp in date_formats)
                Console.WriteLine("  " + kvp.Key + "\t for \t" + kvp.Value);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
