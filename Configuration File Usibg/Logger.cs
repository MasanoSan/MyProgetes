using System;
using System.IO;

namespace Classcreation
{
    public class Logger
    {
        readonly string _Logfilepath;
        public Logger()
        {
            _Logfilepath = $"Log`s_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.txt";
        }
        public void Log(string message)
        {
            string logfirstpart = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText(_Logfilepath, logfirstpart + Environment.NewLine);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            Log("Bивід : " + message);
        }
        public void WriteLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
            Log("Bивід : " + string.Format(message, args));
        }
        public string ReadLine()
        {
            //string input;
            string filler = Console.ReadLine();
            Log($"Ввід : {filler}");
            /*if (filler != null)
            {
                input = filler;
            }
            else
            {
                input = "";
            }*/
            return filler;
        }
    }
}