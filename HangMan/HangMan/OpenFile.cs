using System;
using System.IO;
using System.Text;


namespace HangMan
{
    internal class OpenFile
    {
        public static string ReadFile(string filePath)
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            using (FileStream FS = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
               FS.Read(b,0,b.Length);
            }
            return temp.GetString(b);
        }

    }
}
