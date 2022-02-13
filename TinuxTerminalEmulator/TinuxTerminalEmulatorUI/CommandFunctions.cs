using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxTerminalEmulatorUI
{
    public static class CommandFunctions
    {
        private static string _lastLine = string.Empty;

        //public static void GetLastLine(this FileInfo file)
        //{
        //    using (FileStream fileStream = file.OpenRead())
        //    {
        //        fileStream.Seek(0, SeekOrigin.End);

        //        var allLines = File.ReadAllLines(file.ToString()).ToList();

        //        using (StreamReader sreader = new StreamReader(fileStream))
        //        {
        //            _lastLine = sreader.ReadLine();
        //        }

        //        if (_lastLine == "")
        //        {
        //            using (StreamWriter swriter = file.CreateText())
        //            {
        //                _lastLine = _lastLine.Replace("\n", "");
        //                //swriter.
        //            }
        //        }
        //    }
        //}

        public static List<int> SubStringPosition(this List<string> stringList, string includes)
        {
            int i = 1;

            List<int> lines = new List<int>();

            foreach (string str in stringList)
            {
                if (str.Contains(includes))
                {
                    lines.Add(i);
                }

                i++;
            }

            return lines;
        }

        public static List<string> GetAllLines(this FileInfo file)
        {
            var allLines = File.ReadAllLines(file.ToString()).ToList();

            return allLines;
        }

        public static void WriteLineToFile(this FileInfo file, string write)
        {
            using (StreamWriter swriter = file.CreateText())
            {
                swriter.WriteLine(write);
            }
        }
        public static string ReadLineByIndex(this FileInfo file, int index)
        {
            using (FileStream fileStream = file.OpenRead())
            {
                fileStream.Seek(0, SeekOrigin.Begin);

                using (StreamReader sreader = new StreamReader(fileStream))
                {
                    for (int i = 1; i < index; i++)
                    {
                        sreader.ReadLine();
                    }

                    return sreader.ReadLine();
                }
            }
        }

        //public static List<string> ReadLineByListIndex(this FileInfo file, List<int> indexs)
        //{
        //    List<string> linesInIndex = new List<string>();

        //    using (FileStream fileStream = file.OpenRead())
        //    {
        //        fileStream.Seek(0, SeekOrigin.Begin);

        //        using (StreamReader sreader = new StreamReader(fileStream))
        //        {
        //            int line = 1;

        //            foreach (var index in indexs)
        //            {
        //                while (line < index)
        //                {
        //                    var read = sreader.ReadLine();

        //                    line++;
        //                }

        //                linesInIndex.Add(sreader.ReadLine());

        //                line = 1;

        //                fileStream.Seek(0, SeekOrigin.Begin);
        //            }

        //            return linesInIndex;
        //        }
        //    }
        //}

        public static bool Includes(this string str, string includes)
        {
            
            if (str.Contains(includes))
            {
                return true;
            }
            
            return false;
        }

        public static string GetLastLine(this FileInfo file)
        {
            List<string> lines = File.ReadAllLines(file.ToString()).ToList();
            using (FileStream fileStream = file.OpenRead())
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader sreader = new StreamReader(fileStream))
                {
                    for (int i = 1; i < lines.Count; i++)
                    {
                        sreader.ReadLine();
                    }

                    return sreader.ReadLine();
                }
            }
        }
    }
}
