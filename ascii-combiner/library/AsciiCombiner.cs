using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library
{
    public class AsciiCombiner
    {
        public static IEnumerable<string> Combine(IEnumerable<IEnumerable<string>> files)
        {
            //
            // Validate the list of files
            // 
            if (!IsValidList(files))
            {
                return default;
            }

            return CombineFiles(files);
        }

        public static IEnumerable<string> CombineFiles(IEnumerable<IEnumerable<string>> files)
        {
            var combinedAscii = files.ToList().First().ToList();

            foreach (var file in files)
            {
                // Iterate through lines
                for (var lIndex = 0; lIndex < file.Count(); lIndex++)
                {
                    var line = file.ToList()[lIndex];

                    // Iterate through characters
                    for (var cIndex = 0; cIndex < line.Length; cIndex++)
                    {
                        var character = line[cIndex];

                        if (character != ' ')
                            combinedAscii[lIndex] = combinedAscii[lIndex].ReplaceAt(cIndex, character);
                    }
                }
            }

            return combinedAscii;
        }

        public static bool IsValidList(IEnumerable<IEnumerable<string>> files)
        {
            var list = files.ToList();

            var isHeightValid = list.Count == 0 || list.All(files => files.Count() == list.First().Count());
            var isLineSizeValid = list.Count == 0 || list.All(files => files.ToList().All(lines => lines.Length == files.ToList().First().Length));

            return isHeightValid && isLineSizeValid;
        }
    }
}
