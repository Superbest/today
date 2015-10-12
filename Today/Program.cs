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
            date_formats["-us"] = "MM/dd/yyyy";

            if (args.Count() != 1) Handle_bad_arguments();
            else
            {
                var arg = args[0];
                if (!date_formats.ContainsKey(arg)) Handle_bad_arguments();

                Handle_good_arguments(arg);
            }
        }

        private static void Handle_good_arguments(string arg)
        {
            var today = "";
            var format = date_formats[arg];
            today = DateTime.Now.ToString(format);

            Clipboard.SetText(today);
        }

        private static void Handle_bad_arguments()
        {
            Console.WriteLine(
                "Invalid arguments.\n\nThis program copies today's date in a specified format to the Windows clipboard.\n\nPlease use exactly one of the following arguments:");
            foreach (var kvp in date_formats)
                Console.WriteLine("  " + kvp.Key + "\t for \t" + kvp.Value);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
