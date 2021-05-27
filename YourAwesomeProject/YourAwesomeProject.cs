using System;
using System.IO;

namespace YourAwesomeProject
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryAccess directory = new DirectoryAccess();

            directory.SetInitialPath();
            directory.GetAllDirectoryPaths();
            directory.SetInitialWord();
            directory.ReadAllLinesInFile();

        }
    }



    class DirectoryAccess
    {
        
        private string path;
        public string PathFile
        {
            get { return path; }
            set { path = value; }
        }

        private string[] filePaths;
        private string wordToFind;
        public string WordToFind
        {
            get { return wordToFind; }
            set { wordToFind = value; }
        }

        public void SetInitialPath()
        {
            Console.WriteLine("Write the path: ");
            path = Console.ReadLine();
        }


        public void GetAllDirectoryPaths()
        {
            try
            {
                filePaths = Directory.GetFiles(path);
                Console.WriteLine(filePaths.Length + " files read in directory " + path);
            }
            catch (Exception)
            {
                Console.WriteLine("Given path is not valid");
            }
        }


        public void ReadAllLinesInFile()
        {
            int noMatches = 0;
            foreach (string filePath in filePaths)
            {
                string[] lines = File.ReadAllLines(filePath);

                int count = 0;
                foreach (string line in lines)
                {
                    if (line.Contains(wordToFind))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine(Path.GetFileName(filePath) + " : " + count + " occurrences");
                }
                else
                {
                    noMatches++;
                }
            }

            if (noMatches == filePaths.Length)
            {
                Console.WriteLine("no matches found");
            }
        }


        public void SetInitialWord()
        {
            Console.WriteLine("search> ");
            WordToFind = Console.ReadLine();
        }

    }
}
