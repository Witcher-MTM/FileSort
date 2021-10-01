using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SystemProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string next = String.Empty;
            string[] tmp = { };
            List<string> coolOfElements = new List<string>();
            do
            {

                tmp = Directory.GetFiles(@$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" + @"\Downloads", "*", SearchOption.AllDirectories);
                string format = Program.Menu();
                Console.Clear();
                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    if (format == "*")
                    {
                        coolOfElements.Add(tmp[i]);
                        Console.WriteLine($"Element [{i}]:" + Path.GetFileName(tmp[i]));
                    }
                    if (tmp[i].EndsWith("." + format))
                    {
                        coolOfElements.Add(tmp[i]);
                        Console.WriteLine($"Element [{i}]:" + Path.GetFileName(tmp[i]));
                    }
                }
                if (coolOfElements.Count <= 0)
                {
                    Console.WriteLine("Not exist files with " + $"{format} " + "format");
                }
                else
                {
                    Console.WriteLine("Save files [Y] - [N]");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Saves(coolOfElements);
                    }

                }



                Console.WriteLine("Do you want to continue?");
                Console.WriteLine("[Y]-continue [N]-exit");
                next = Console.ReadLine();
                Console.Clear();
            } while (next.ToLower() != "n");
            Environment.Exit(0);

        }
        static string Menu()
        {
            Console.WriteLine("Choose a format:jpg exe png and ect\n Enter * to see all files");
            string choose = Console.ReadLine();

            return choose;
        }
        static void Saves(List<string> allapps)
        {
            CreateDir();
            string[] musFormat = { "mp3", "mp4", "wav", "mp2", "mpc", "wma", "mqa", "ac3", "ape", "asf", "aiff" };
            string[] docFormat = { "doc", "xml", "rtf", "txt", "wps", "pdf", "html", "htm", "dot", "docx", "dotm", "dotx" };
            string[] rarFormat = { "zip", "arj", "rar", "cab", "tar", "lzh" };
            string[] codeFormat = { "cs", "sln", "csproj", "dll" };
          
            foreach (var item in allapps)
            {
                foreach (var mus in musFormat)
                {
                    if (item.EndsWith("."+ mus))
                    {
                        File.Copy(item, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Music\\" + Path.GetFileName(item));
                    }
                }
                foreach (var doc in docFormat)
                {
                    if (item.EndsWith("." + doc))
                    {
                        File.Copy(item, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Documents\\" + Path.GetFileName(item));
                    }
                }
                foreach (var rar in rarFormat)
                {
                    if (item.EndsWith("." + rar))
                    {
                        File.Copy(item, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Rar\\" + Path.GetFileName(item));
                    }
                }
                foreach (var code in codeFormat)
                {
                    if (item.EndsWith("." + code))
                    {
                        File.Copy(item, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Code\\" + Path.GetFileName(item));
                    }
                }
               
            }
        }
        static void CreateDir()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Music\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Music\\");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Documents\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Documents\\");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Rar\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Rar\\");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Code\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Code\\");
        }
    }

}
