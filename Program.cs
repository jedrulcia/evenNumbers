using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Channels;

namespace EvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "file.txt";
            string newFile = "newfile.txt";
            if (File.Exists(path)) CreatingFile(path, newFile);
            else Console.WriteLine("file.txt is missing in the main folder");
        }
        static void CreatingFile(string path, string newFile)
        {
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
            string content = File.ReadAllText(path);
            File.Create(content);
            int[] t1 = CreatingIntTab(content);
            string text = CreatingText(t1);
            File.WriteAllText(newFile, text);
        }
        static int[] CreatingIntTab(string content)
        {
            string newcontent = "";
            content = content + " ";
            int[] t1 = Array.Empty<int>();
            for (int index = 0, tabIndex = 0; index < content.Length; index++)
            {
                if (content.Substring(index, 1) != " ")
                {
                    newcontent = newcontent + content.Substring(index, 1);
                }
                else
                {
                    if (Convert.ToInt32(newcontent) % 2 == 0)
                    {
                        Array.Resize(ref t1, tabIndex + 1);
                        t1[tabIndex] = Convert.ToInt32(newcontent);
                        newcontent = "";
                        tabIndex++;
                    }
                    else
                    {
                        newcontent = "";
                    }
                }
            }
            return t1;
        }
        static string CreatingText(int[] t1)
        {
            string text = "";
            for (int index = 0; index < t1.Length; index++)
            {
                text = text + Convert.ToString(t1[index]) + " ";
            }
            return text;
        }
    }
}
