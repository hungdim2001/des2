using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_Hoa
{
    class Key_Gen
    {



        public string Text_result = "";

        private int[] store_num = new int[56];
        private int[] store_num1 = new int[48];
        private int[,] PC_1 ={{57 ,49 ,41 ,33 ,25 ,17 ,9},
    {1, 58, 50, 42, 34, 26, 18},
    {10, 2,59, 51, 43, 35, 27},
    {19, 11, 3, 60, 52, 44, 36},
    {63, 55, 47, 39, 31, 23, 15},
    {7, 62, 54, 46, 38, 30, 22},
    {14, 6, 61, 53, 45, 37, 29},
    {21, 13, 5 ,28, 20, 12, 4}
    };
        private int[,] PC_2 ={{14, 17, 11, 24, 1, 5},
    {3, 28, 15, 6, 21, 10},
    {23, 19, 12, 4,26, 8},
    {16, 7, 27, 20, 13, 2},
    {41, 52, 31, 37, 47, 55},
    {30, 40, 51, 45, 33, 48},
    {44, 49, 39, 56, 34, 53},
    {46, 42, 50, 36, 29, 32}
    };
        private String key;
        private String[,] keyS = new String[7,8];
        private String[,] cS = new String[4, 7];
        private String[,] dS = new String[4, 7];
        private String[,] finalS = new String[6, 8];

        public Key_Gen() { }

        public virtual void FillPC_1()
        {
            int index = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    store_num[index] = PC_1[row, col];
                    index++;
                }
            }

        }
        public void FillPC_2()
        {
            int index = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    store_num1[index] = PC_2[row, col];
                    index++;
                }
            }
        }
        public void DoPC_1(int[] key_in, int[] key_out)
        {
            int temp = 0;
            int i = 0;
            int loop = 0;
            int check = 0;
            while (check != 56)
            {
                temp = store_num[i];
                if (temp == loop)
                {
                    key_out[check] = key_in[loop - 1];
                    loop = 0;
                    check++;
                    i++;
                }
                loop++;
            }

            //  System.out.println("The Permutted key");
            Text_result += "\n The Permutted key: ";
            for (int j = 0; j < key_out.Count(); j++)
            {
                // System.out.print(key_out[j]);
               // Console.Write(key_out[j]);
                Text_result += key_out[j];
                /// tim hieu sau
            }

            int index = 0;
            for (int g = 0; g < 7; g++)
            {
                for (int j = 0; j < 8; j++)
                {
                    keyS[g, j] = Convert.ToString(key_out[index]);
                    index++;
                }
            }
            Text_result+= Arrayprinter.output_Array(keyS, "\n After PC-1");
         
        }
        public void DoPC_2(int[] key_in, int[] key_out)
        {
            int temp = 0;
            int i = 0;
            int loop = 0;
            int check = 0;
            while (check != 48)
            {
                temp = store_num1[i];
                if (temp == loop)
                {
                    key_out[check] = key_in[loop - 1];
                    loop = 0;
                    check++;
                    i++;
                }
                loop++;
            }

            int index = 0;
            for (int g = 0; g < 6; g++)
            {
                for (int j = 0; j < 8; j++)
                {
                    finalS[g,j] = Convert.ToString(key_out[index]);
                    index++;
                }
            }

         Text_result+=   Arrayprinter.output_Array(finalS, "\n _After PC-2");
            index = 0;
        }
        public string DoSegementation(int[] key_out, int[] C, int[] D)
        {
            string temp1 = "";
            int index = 0;
            for (int i = 0; i < 28; i++)
                C[i] = key_out[i];

            for (int i = 28; i < 56; i++)
            {
                D[index] = key_out[i];

                index++;
            }


            index = 0;
            for (int g = 0; g < 4; g++)
            {
                for (int j = 0; j < 7; j++)
                {
                    cS[g,j] = Convert.ToString(key_out[index]);
                    index++;
                }

            }

            for (int g = 0; g < 4; g++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dS[g,j] = Convert.ToString(key_out[index]);
                    index++;
                }



            }
            index = 0;

            temp1 += Arrayprinter.output_Array(cS, "Segment Key to C part");
            temp1 += Arrayprinter.output_Array(dS, "Segment Key to D part");
            return temp1;
        }

        public string Do_OneLeftShitf(int[] side1, int[] side2)
        {
            string temp_result = "";
            int temp = side1[0];
            for (int i = 1; i < side1.Count(); i++)
            {

                side1[i - 1] = side1[i];


            }
            side1[side1.Count() - 1] = temp;
            temp = side2[0];
            for (int i = 1; i < side2.Count(); i++)
            {

                side2[i - 1] = side2[i];


            }
            side2[side2.Count() - 1] = temp;

            temp_result+="After One left shift";
            for (int j = 0; j < side1.Count(); j++)
            {
                temp_result+=side1[j];
            }
            return temp_result;
        }
    }
}
