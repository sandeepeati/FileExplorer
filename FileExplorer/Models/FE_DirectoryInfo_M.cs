using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorer.Models
{
    public class FE_DirectoryInfo_M
    {
        public string Name { get; set; }
        public FE_DirectoryContents_M Contents { get; set; }
        public bool IsHidden { get; set; }
        public string FolderImage { get; set; }
    }

    public class FE_DirectoryContents_M
    {
        public DirectoryInfo[] Directories { get; set; }
        public FileInfo[] Files { get; set; }
    }
}
