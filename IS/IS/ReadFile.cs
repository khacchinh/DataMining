using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    class ReadFile
    {
        public ReadFile()
        {

        }

        public static List<List<String>> readDataFromFile(String path, ref int ins)
        {
            String line;
            List<List<String>> list_String = new List<List<String>>();
            try
            {
                int count = 0;
                List<String> arr_header = new List<String>();
                List<String> arr_data = new List<String>();
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, 1).Equals("@"))
                        arr_header.Add(line.Substring(1, line.Length - 1));
                    else if (line.Substring(0, 1).Equals("-"))
                    {
                        Class class_item = new Class();
                        class_item.Class_Item = line.Substring(1, line.Length - 1);
                        Form1.addClass(class_item);
                    }
                    else
                        arr_data.Add(line);
                }
                ins = arr_data.Count;
                list_String.Add(arr_header);
                list_String.Add(arr_data);
            }
            catch
            {
                Console.WriteLine("Oop!!! Something wrong :'( ");
            }
            return list_String;
        }
    }
}
