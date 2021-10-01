using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SystemProj
{
    class Program
    {
        static Dictionary<string, List<string>> folders = new Dictionary<string, List<string>> {
           { "Text", new List<string> { ".txt", ".doc",".pdf"} },
           { "Images", new List<string> { ".png", ".jpeg",".ico",".jpg" } },
           { "Programs", new List<string> { ".exe" } },
           { "Videos", new List<string> { ".avi", ".mp4",".gif" } },
           { "Music", new List<string> { ".mp3", ".wav",".ogg" } },
           { "Archive", new List<string> { ".zip", ".rar" } },
           { "Code", new List<string> { ".cs", ".html",".php",".cpp",".js" } }

        };
        static string path = String.Empty;
        static void Main(string[] args)
        {
            string next = String.Empty;
            List<string> coolOfElements = new List<string>();
            do
            {
                path = args[0];
                path += @"\";
                if (Directory.Exists(path))
                {
                    coolOfElements.AddRange(Directory.GetFiles(path).Select(Path.GetFileName).ToList());
                    Console.Clear();
                    for (int i = 0; i < coolOfElements.Count; i++)
                    {
                        Console.WriteLine($"Element [{i}]:" + coolOfElements[i]);
                    }
                    if (coolOfElements.Count <= 0)
                    {
                        Console.WriteLine("Not exist files");
                    }
                    else
                    {
                        Console.WriteLine("Sort files [Y] - [N]");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            SortFiles(coolOfElements);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not exists this dir");
                }

                Console.WriteLine("Do you want to continue?");
                Console.WriteLine("[Y]-continue [N]-exit");
                next = Console.ReadLine();
                Console.Clear();

            } while (next.ToLower() != "n");
            Environment.Exit(0);

        }
        static void SortFiles(List<string> allapps)
        {
            CreateDir();
            foreach (var item in folders)
            {
                foreach (var format in item.Value)
                {
                    allapps.Where(x => x.Contains(format)).ToList().ForEach(f => { File.Move($"{path + f}", $"{path + item.Key}\\{f}"); });

                }
            }
            allapps = Directory.GetFiles(path).Select(Path.GetFileName).ToList();
            allapps.ToList().ForEach(y => { File.Move($"{path + y}", $"{path}Other\\{y}"); });

            DeleteEmptyDir();


        }
        static void CreateDir()
        {

            for (int i = 0; i < folders.Count; i++)
            {
                if (Directory.Exists($"{path + folders.ElementAt(i).Key}") == false)
                    Directory.CreateDirectory($"{path + folders.ElementAt(i).Key}");
            }
            Directory.CreateDirectory($"{path}Other");
        }
        static void DeleteEmptyDir()
        {
            List<string> dirs = Directory.GetDirectories(path).ToList();
            foreach (var item in dirs)
            {
                if (Directory.GetFiles(item).Length == 0)
                    Directory.Delete(item);
            }
        }
    }

}
