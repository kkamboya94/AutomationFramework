using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabaTalksTestFramework.Helpers
{
    public class LogHelpers
    {
        //log file name
        private static string _logFileName = string.Format("{0:ddMMyyyyhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //create a file which can store the log information
        public static void CreateLogFile()
        {
            string logfolderpath = System.IO.Directory.GetCurrentDirectory();
            string dir = @"TestLogs\";
            CombinePaths(logfolderpath, dir);
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //to combine the directory and the log folder path
        private static void CombinePaths(string logfolderpath, string dir)
        {
            string combination = Path.Combine(logfolderpath, dir);
        }

        //write text in the log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("   {0}", logMessage);
            _streamw.Flush();
        }

    }

}
