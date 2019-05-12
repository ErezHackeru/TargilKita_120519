using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    interface IFileAttributes
    {        
        void PrintFile();
        int FileSize { get; }
        bool IsReadOnly { get; }
        bool IsArchive { get; }
        bool IsInfected { get; }
    }
}
