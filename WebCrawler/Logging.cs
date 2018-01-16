using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace WebCrawler
{
    public static class Logging
    {
        public static void WriteToFile(string contents)
        {
            string filePath = ConfigurationManager.AppSettings["logsPath"].ToString();
            string fileName = Directory.GetCurrentDirectory() +
                $"{filePath}\\log-{DateTime.Now.ToString("yyyyMMdd hh-mm-ss")}.txt";

            FileStream fStream = null;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                fStream = File.Create(fileName);
            }
            else
            {
                fStream = File.OpenWrite(fileName);
            }

            using (TextWriter writer = new StreamWriter(fStream))
            {
                writer.WriteLine(contents);
                writer.Flush();
            }

            fStream.Dispose();
        }
    }
}
