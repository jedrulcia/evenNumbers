This is my C# code that takes all even numbers from the text file and saves them into new text file. To run this code properly, user needs to create a text file named "file.txt" in "net5.0" folder (\evenNumbers\bin\Debug\net5.0).


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
            if (t1 != null)
            {
                string text = CreatingText(t1);
                File.WriteAllText(newFile, text);
                Console.WriteLine("newFile.txt has been created properly.");
            }
            
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
                    try
                    {
                        int num = Int32.Parse(newcontent);
                    }
                    catch
                    {
                        Console.WriteLine(newcontent + " is not integer. Text file is incorrect.");
                        return null;
                    }
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
