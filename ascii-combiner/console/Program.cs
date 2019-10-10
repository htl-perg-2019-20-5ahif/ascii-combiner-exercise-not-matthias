using library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please select at least two files.");
                return;
            }

            //
            // Open the files and read the input
            //
            var files = new List<IEnumerable<string>>();
            foreach (var file in args)
            {
                try
                {
                    var fileContent = File.ReadAllText(file);
                    files.Add(fileContent.Replace("\r", "").Split("\n"));
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed to open file \"{file}\".");
                    return;
                }
            }

            //
            // Validate the files
            //
            if (!AsciiCombiner.IsValidList(files))
            {
                Console.WriteLine("Missformed files found.");
                return;
            }

            //
            // Combine the ascii
            //
            var combinedAscii = AsciiCombiner.Combine(files);
            combinedAscii.ToList().ForEach(Console.WriteLine);
        }
    }
}
