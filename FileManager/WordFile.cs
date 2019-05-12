using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class WordFile : MyFile, IWordCounter, ISpecificWordCount
    {
        public override void PrintFile()
        {
            string[] Allwords = AllFileText.Split(' ');
            foreach (string word in Allwords)
            {
                Console.WriteLine(word);
            }
        }
        Dictionary<string, int> words = new Dictionary<string, int>();

        public string AllFileText { get; set; }        

        public WordFile(string text, string filePath, int fileSize, bool isReadOnly, bool isArchive) : base(filePath, fileSize, isReadOnly, isArchive )
        {
            AllFileText = text;
            int value;
            string[] Allwords = AllFileText.Split(' ');
            foreach (string word in Allwords)
            {
                words.TryGetValue(word, out value);
                if (value == 0)
                {
                    words.Add(word, 1);
                }
                else
                {
                    value++;
                    words[word] = value;
                }
                value = 0;
            }
        }

        public int GetSpecificWordCount(string textWord)
        {
            if (words.ContainsKey(textWord))
                return words[textWord];
            else
                return -1;
        }

        //IWordCounter implement
        public int NumberOfWords
        {
            get
            {
                string[] Allwords = AllFileText.Split(' ');
                return Allwords.Length;
            }
        }

        public int NumberOfPages
        {
            get
            {
                return (NumberOfWords / 10);
            }
        }

        public string this[int index]
        {
            get
            {
                string[] Allwords = AllFileText.Split(' ');
                return Allwords[index];
            }
        }

        public static bool operator ==(WordFile x, WordFile y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            if (x.AllFileText == y.AllFileText)
                return true;
            return false;
        }

        public static bool operator !=(WordFile x, WordFile y)
        {
            return !(x == y);
        }
        public override int GetHashCode()
        {
            return this.AllFileText.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            WordFile otherFile = obj as WordFile;
            if (otherFile == null)
                return false;
            return (otherFile.AllFileText == this.AllFileText);
        }

        public static WordFile operator +(WordFile wf1, WordFile wf2)
        {
            WordFile bigger = (wf1.FileSize > wf2.FileSize) ? wf1 : wf2;

            return new WordFile(wf1.AllFileText + wf2.AllFileText, bigger.filePath + ".mrg", bigger.FileSize, bigger.IsReadOnly, bigger.IsArchive);
        }
    }
}
