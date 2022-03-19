using System;
using System.IO;
using System.Linq;

namespace HackersDiscordBot
{
    internal class FileReader
    {
        private static Random rng = new Random();
        internal static string ReadAlexFile()
        {
            //get to file
            var path = $"{Directory.GetCurrentDirectory()}/AlexQuotes.txt";

            try
            {
                //read
                var text = File.ReadAllLines(path);

                //return results
                return text[rng.Next(text.Length)];
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }            
        }

        internal static string GetAlexPhoto()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\../images");

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var files = directoryInfo.EnumerateFiles().ToList();

            return files[rng.Next(files.Count)].FullName;
        }
    }
}