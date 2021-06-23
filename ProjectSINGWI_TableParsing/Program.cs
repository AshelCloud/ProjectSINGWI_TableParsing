using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace ProjectSINGWI_TableParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            string TypePath = "";
            string DataPath = "";
            string HeaderPath = "";
            string JsonPath = "";


#if DEBUG
            TypePath = "C:/Users/PC5/Desktop/Test/Type";
            DataPath = "C:/Users/PC5/Desktop/Test/Data";
            HeaderPath = "C:/Users/PC5/Desktop/Test/Files/";
            JsonPath = "C:/Users/PC5/Desktop/Test/Files/";
#else

            for (int i = 0; i < args.Length; i += 2)
            {
                string str = args[i].ToLower();

                if(str.Contains("--"))
                {
                    if(str.Contains("typepath"))
                    {
                        DataPath = args[i + 1];
                    }
                    else if (str.Contains("datapath"))
                    {
                        DataPath = args[i + 1];
                    }
                    else if(str.Contains("jsonpath"))
                    {
                        JsonPath = args[i + 1];
                    }
                    else if(str.Contains("headerpath"))
                    {
                        HeaderPath = args[i + 1];
                    }
                }
            }
#endif

            if (TypePath.Equals(""))
            {
                Console.WriteLine("TypePath 설정되지않음");
                return;
            }
            if (DataPath.Equals(""))
            { 
                Console.WriteLine("DataPath 설정되지않음");
                return;
            }

            if (HeaderPath.Equals(""))
            {
                Console.WriteLine("HeaderPath 설정되지않음");
                return;
            }

            if (JsonPath.Equals(""))
            {
                Console.WriteLine("JsonPath 설정되지않음");
                return;
            }

            List<string> TypeList = FileManager.GetFileList(TypePath);
            List<string> DataList = FileManager.GetFileList(DataPath);

            ExcelManager.Generate(TypeList, DataList, JsonPath, HeaderPath);

            Process[] excelProcs = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in excelProcs)
            {
                proc.Kill();
            }
        }
    }
}
