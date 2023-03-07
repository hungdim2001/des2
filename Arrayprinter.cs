using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_Hoa
{
    class Arrayprinter
    {
         public Arrayprinter() { }
         public static string output_Array(string [,]arr,string label)
        {
            string temp_result = "\r\n--"+label+"--"+"\r\n";
            for(int i=0; i < arr.GetLength(0); i++)// de sai
            {
                temp_result += "\r\n |";
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    temp_result += arr[i,j] + " ";
                }
                temp_result += "|";
            }
            return temp_result + "\r\n";
            
        }
    }
}
