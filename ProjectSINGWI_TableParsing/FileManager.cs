using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectSINGWI_TableParsing
{
    static class FileManager
    {
        public static List<string> GetFileList(string FolderPath)
        { 
            List<string> Result = new List<string>();

            DirectoryInfo Info = new DirectoryInfo(FolderPath);
            foreach(FileInfo File in Info.GetFiles())
            {
                if(File.Extension.ToLower().CompareTo(".xlsx") == 0)
                {
                    Result.Add(File.FullName);
                }
            }

            return Result;
        }
    }
}
