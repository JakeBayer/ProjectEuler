using System;
using System.IO;
using System.Linq;

namespace ProjectEuler.Utils
{
    /// <summary>
    /// SUPER SPECIFIC FILE OPENER. Assumes every problem is in the same folder structure. Will throw error if not.
    /// <remarks>Not for use outside this project</remarks>
    /// </summary>
    public static class FileHelper
    {
        public static FileHelperWithPath ForProblem(int problem)
        {
            var nearestFifty = problem - (problem - 1) % 50;
            var nearestTen = problem - (problem - 1) % 10;
            return new FileHelperWithPath(@"~\..\..\..\Problems\"
                + Pad(nearestFifty.ToString(), 3) + "-" + Pad((nearestFifty + 49).ToString(), 3)
                + @"\" + nearestTen.ToString() + "-" + (nearestTen + 9).ToString()
                + @"\Problem" + problem.ToString() + @"\");
        }

        private static string Pad(string str, int len)
        {
            if (str.Length < len)
            {
                str = String.Join("", Enumerable.Repeat('0', len - str.Length)) + str;
            }
            return str;
        }

        public class FileHelperWithPath
        {
            private readonly string _filePathBase;
            public FileHelperWithPath(string filePathBase)
            {
                _filePathBase = filePathBase;
            }

            public StreamReader OpenFile(string fileName)
            {
                if (string.IsNullOrWhiteSpace(_filePathBase))
                {
                    throw new Exception("For which problem tho?");
                }
                return new StreamReader(_filePathBase + fileName);
            }
        }
    }
}
