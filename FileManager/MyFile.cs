using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public abstract class MyFile : IFileAttributes, IComparable
    {
        public MyFile()
        {

        }
        readonly string _filePath;
        public string filePath
        {
            get
            {
                return _filePath;
            }
        }
        static List<string> paths = new List<string>();
        protected MyFile(string filePath)
        {
            this._filePath = filePath;
            paths.Add(filePath);
        }

        const bool IsfileSupportHebrew = true;
        public abstract void PrintFile();


        public int FileSize { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool IsArchive { get; private set; }
        public bool IsInfected { get; private set; }

        public MyFile(string filePath, int fileSize, bool isReadOnly, bool isArchive) : this(filePath)
        {
            FileSize = fileSize;
            IsReadOnly = isReadOnly;
            IsArchive = isArchive;

            IsInfected = VirusScanner.IsFileInfected(this);
        }

        public int CompareTo(object obj)
        {
            MyFile newFile = obj as MyFile;
            return (this.FileSize - newFile.FileSize);
        }

        public static bool operator ==(MyFile x, MyFile y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            if (x.filePath == y.filePath)
                return true;
            return false;
        }

        public static bool operator !=(MyFile x, MyFile y)
        {
            return !(x == y);
        }
        public override int GetHashCode()
        {
            return this.filePath.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MyFile otherFile = obj as MyFile;
            if (otherFile == null)
                return false;
            return (otherFile.filePath == this.filePath);
        }
    }

    public class CompareAsFilePath : IComparer<MyFile>
    {
        public int Compare(MyFile x, MyFile y)
        {
            return x.filePath.CompareTo(y.filePath);
        }
    }
}
