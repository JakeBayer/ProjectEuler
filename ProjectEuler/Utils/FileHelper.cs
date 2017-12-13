using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                + nearestFifty.ToString() + "-" + (nearestFifty + 49).ToString()
                + @"\" + nearestTen.ToString() + "-" + (nearestTen + 9).ToString()
                + @"\Problem" + problem.ToString() + @"\");
        }

        public class FileHelperWithPath
        {
            private string _filePathBase;
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
