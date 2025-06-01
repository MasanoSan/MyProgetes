using System;
using System.IO;

namespace Classcreation
{
    public class Userinfo
    {
        private string filePath;
        public Userinfo(string FileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), FileName);
            if (File.Exists(filePath) != true)
            {
                File.Create(filePath);
            }
        }
        public void WritingUserInfo()
        {
            string userinput = Console.ReadLine();
            File.AppendAllText(filePath, userinput);
        }
        public string ReaderInfo()
        {
                return File.ReadAllText(filePath);
        }
    }
}