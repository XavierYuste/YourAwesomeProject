using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace YourAwesomeProject
{
    /// <summary>
    /// The main thread program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Initializes the main functionality of the code.
        /// </summary>
        static void Main(string[] args)
        {
            DirectoryDirector directory = new DirectoryDirector();
            Builder b = new BuilderDirectoryAccess();
            directory.Construct(b);
        }
    }


    /// <summary>
    /// Has the main funcionalities of the DirectoryAccess.
    /// </summary>
    class DirectoryAccess
    {
        private string path;
        private string[] filePaths;
        private string wordToFind;
        public string PathFile
        {
            get { return path; }
            set { path = value; }
        }
        public string WordToFind
        {
            get { return wordToFind; }
            set { wordToFind = value; }
        }

        /// <summary>
        /// Initializes the first given path.
        /// </summary>
        public void SetInitialPath()
        {
            Console.WriteLine("Write the path: ");
            path = Console.ReadLine();

            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    filePaths = Directory.GetFiles(path);
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Given path is not valid, please enter a valid path: ");
                    path = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Initializes the word.
        /// </summary>
        public void SetInitialWord()
        {
            Console.WriteLine("search> ");
            WordToFind = Console.ReadLine();
        }

        /// <summary>
        /// Gets all the directory paths.
        /// </summary>
        public void GetAllDirectoryPaths()
        {
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    Console.WriteLine(filePaths.Length + " files read in directory " + path);
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Given path is not valid");
                }
            }
        }

        /// <summary>
        /// Counts the words in the given files.
        /// </summary>
        public void ReadAllLinesInFile()
        {
            int noMatches = 0;
            Dictionary<string, int> fileCounter = new Dictionary<string, int>();

            foreach (string filePath in filePaths)
            {
                string[] lines = File.ReadAllLines(filePath);

                int count = File.ReadLines(filePath)
.Select(line => Regex.Matches(line, wordToFind).Count)
.Sum();

                if (count > 0)
                {
                    fileCounter.Add(Path.GetFileName(filePath), count);
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
            else
            {
                var sortedDict = from entry in fileCounter orderby entry.Value descending select entry;

                int processed = 0;
                foreach (var item in sortedDict)
                {
                    Console.WriteLine(item.Key + " : " + item.Value + " occurrences");
                    if (++processed == 9) break;
                }
            }

            System.Threading.Thread.Sleep(10000);

        }

    }

    class DirectoryDirector
    {
        /// <summary>
        /// Builds the builder.
        /// </summary>
        public void Construct(Builder builder)
        {
            builder.BuildPath();
            builder.BuildWord();
            builder.BuildAllDirectoryPaths();
            builder.BuildAllLinesInFile();
        }
    
    }

    /// <summary>
    /// Abstract Builder class to have the DirectoryAccess.
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPath();

        public abstract void BuildWord();

        public abstract void BuildAllDirectoryPaths();

        public abstract void BuildAllLinesInFile();

        public abstract DirectoryAccess GetResult();

    }

    /// <summary>
    /// Builds the constructor of the DirectoryAccess.
    /// </summary>
    class BuilderDirectoryAccess : Builder
    {
        private DirectoryAccess _directory = new DirectoryAccess();

        public override void BuildPath()
        {
            _directory.SetInitialPath();
        }

        public override void BuildWord()
        {
            _directory.SetInitialWord();
        }

        public override void BuildAllDirectoryPaths()
        {
            _directory.GetAllDirectoryPaths();
        }

        public override void BuildAllLinesInFile()
        {
            _directory.ReadAllLinesInFile();
        }

        public override DirectoryAccess GetResult()
        {
            return _directory;
        }

    }

}
