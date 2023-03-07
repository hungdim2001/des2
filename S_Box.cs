using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_Hoa
{
    class S_Box
    {
        public S_Box() { }
        private int index = 0;
        private int[] func_out = new int[32];
        private int[] store_num = new int[32];
        private String text48;
        private int[] after_SBox = new int[32];
        private int index1 = 0;
        private int index2 = 0;
        private int row = 0;
        private int col = 0;
        private int[] SBox_Result = new int[8];
        private int[] SBox_row = new int[8];
        private int[] SBox_col = new int[8];
        private int[] dec1 = new int[2];
        private int[] dec2 = new int[4];
        private int[] temp = new int[6];
        public string Text_result="";
         private int[][] SBOX1 = new int[][]
         
 {
	 new int[] {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
	 new int[] {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
	 new int[] {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
	 new int[] {15, 12, 8, 2, 4, 9, 1, 7,5, 11, 3, 14, 10, 0, 6, 13}
 };

	private int[][] SBOX2 = new int[][]
	{
		new int[] {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12,0, 5, 1},
		new int[] {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9,11, 5},
		new int[] {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
		new int[] {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
	};

	private int[][] SBOX3 = new int[][]
	{
		new int[] {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
		new int[] {13, 7, 0, 9, 3, 4, 6, 10, 2,8,5,14, 12, 11, 15, 1},
		new int[] {13, 6, 4, 9, 8,15,3,0, 11, 1, 2, 12, 5, 10, 14, 7},
		new int[] {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
	};

	private int[][] SBOX4 = new int[][]
	{
		new int[] {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
		new int[] {13,8,11,5, 6,15, 0,3,4,7,2,12,1,10,14,9},
		new int[] {10, 6, 9, 0, 12, 11, 7,13, 15, 1, 3, 14, 5, 2, 8, 4},
		new int[] {3, 15, 0, 6, 10, 1, 13, 8, 9, 4,5,11,12, 7, 2, 14}
	};

	private int[][] SBOX5 = new int[][]
	{
		new int[] {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
		new int[] {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3,9,8,6},
		new int[] {4,2, 1, 11, 10, 13, 7,8,15, 9, 12, 5, 6, 3, 0, 14},
		new int[] {11, 8, 12,7, 1, 14,2,13,6,15, 0,9, 10, 4, 5, 3}
	};

	private int[][] SBOX6 = new int[][]
	{
		new int[] {12,1,10,15, 9,2, 6,8,0,13,3,4,14,7,5,11},
		new int[] {10, 15, 4,2,7,12,9, 5, 6, 1, 13,14,0, 11, 3,8},
		new int[] {9, 14, 15, 5, 2,8,12, 3, 7,0,4,10, 1, 13,11,6},
		new int[] {4, 3, 2, 12, 9, 5, 15,10,11, 14, 1, 7, 6, 0, 8, 13}
	};

	private int[][] SBOX7 = new int[][]
	{
		new int[] {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7,5,10,6,1},
		new int[] {13, 0, 11, 7, 4, 9, 1, 10, 14,3,5, 12, 2, 15, 8, 6},
		new int[] {1, 4, 11, 13, 12, 3, 7,14, 10, 15, 6, 8, 0, 5, 9, 2},
		new int[] {6, 11, 13, 8,1,4, 10, 7, 9, 5,0,15,14, 2, 3, 12}
	};
	private int[][] SBOX8 = new int[][]
	{
		new int[] {13, 2, 8, 4, 6, 15, 11, 1,10, 9, 3, 14, 5, 0, 12, 7},
		new int[] {1, 15, 13, 8,10, 3,7,4,12, 5, 6,11, 0, 14, 9, 2},
		new int[] {7, 11, 4, 1,9,12,14,2,0,6,10, 13,15,3,5,8},
		new int[] {2, 1, 14, 7,4,10, 8,13, 15, 12, 9, 0, 3, 5, 6, 11}
	};
	private int[][] P = new int[][]
	{
		new int[] {16,7,20,21},
		new int[] {29, 12, 28, 17},
		new int[] {1, 15, 23, 26},
		new int[] {5, 18, 31, 10},
		new int[] {2,8,24,14},
		new int[] {32, 27, 3, 9},
		new int[] {19, 13, 30, 6},
		new int[] {22, 11, 4, 25}
	};

        private String [,]after_SBoxs= new String[4,8];
    private String [,]func_outS= new String[4,8];
        public void DoDecimal(int[] num)
        {
            dec1[0] = num[0];
            dec1[1] = num[5];
            row = dec1[1] + 2 * dec1[0];
            
        }


        public void DoFourDecimal(int [] num)
        {
            dec2[0] = num[1];
            dec2[1] = num[2];
            dec2[2] = num[3];
            dec2[3] = num[4];
            col = dec2[3] + 2 * dec2[2] + 4 * dec2[1] + 8 * dec2[0];
        }
        public void SelectSBox( int choice, int row, int col)
        {
            switch (choice)
            {
                case 0:
                    SBox_Result[index1] = SBOX1[row][col];
                    index1++; break;
                case 1:
                    SBox_Result[index1] = SBOX2[row][col];
                    index1++; break;

                case 2:
                    SBox_Result[index1] = SBOX3[row][col];
                    index1++; break;
                case 3: SBox_Result[index1] = SBOX4[row][col];
                    index1++;
                    break;
                case 4:
                    SBox_Result[index1] = SBOX5[row][col];
                    index1++;
                    break;
                case 5: SBox_Result[index1] = SBOX6[row][col];
                    index1++;
                    break;
                case 6: SBox_Result[index1] = SBOX7[row][col];
                    index1++;
                    break;
                case 7: SBox_Result[index1] = SBOX8[row][col];
                    index1++;
                    break;
            }
        }

        public string make32bit(int num) {
            string temp_result = "";
            int num1 = 0;
            int num2, num3;
            num1 = num;
            temp_result += " \r\n code ";
           for( int i=0; i < 4; i++)
            {
                num3 = num1 / 2;
                num2 = num1 % 2;
                num1 = num3;
                after_SBox[index2] = num2;
                temp_result += after_SBox[index2]+"\n";
                index2++;


            }
            return temp_result;
        }
        public void Reverse(int[] num)
        {
            int count = 0;
            int fix = 3;
            int temp1;
            while (count != 32)
            {
                for (int i = 0; i < 2; i++)
                {

                    temp1 = num[count + i];

                    num[count + i] = num[fix - (count + i)];
                    num[fix - (count + i)] = temp1;

                }
                fix += 8;
                count += 4;
            }


        }

        public void Fill_P()
        {
            int index = 0;
             for(int row=0; row < 8; row++)
               for(int col=0; col < 4; col++)
                {
                    store_num[index] = P[row][col];
                    index++;
                }
        }

        public void Do_P(int [] after_Sbox, int[] Func_out)
        {
            int temp = 0;
            int i = 0;
            int loop = 0;
            int check = 0;
            while (check != 32)
            {
                temp = store_num[i];
                if (temp == loop)
                {
                    func_out[check] = after_SBox[loop - 1];
                    loop = 0;
                    check++;
                    i++;

                }
                loop++;

            }
        }

         public string Do_S_Box(int[]XoR_out,int[] S_out)
        {
            string temp_result = "";
            temp_result += "\r\n-------------------------S-Box Stages--------------------------\r\n";
            int count = 0;
            int choice = 0;
            int i;
            index = 0;
            while (count != 48)
            {
                for (i = 0; i < 6; i++)
                    temp[i] = XoR_out[i + count];

                DoDecimal(temp);
                DoFourDecimal(temp);
                SBox_row[index] = row;
                SBox_col[index] = col;
                SelectSBox(choice, SBox_row[index], SBox_col[index]);

                Text_result += index + "=" + SBox_Result[index] + "Row" + row + "Col" + col + "\r\n";
                temp_result+= make32bit(SBox_Result[index]);
                index++;
                choice++;
                count += 6;
            }
            Reverse(after_SBox);
            index = 0;
            for (int d = 0; d < 4; d++)
            {
                for (int j = 0; j < 8; j++)
                {
                    after_SBoxs[d,j] = Convert.ToString(after_SBox[index]);
                    index++;
                }
            }
            index = 0;
            temp_result += Arrayprinter.output_Array(after_SBoxs, "Final Result After SBoxes");
            //viet sauarrayprinter.printarray(after_SBoxs,"Final Result After SBoxes");
            Fill_P();
            Do_P(after_SBox, func_out);
            for (int d = 0; d < 4; d++)
            {
                for (int j = 0; j < 8; j++)
                {
                    func_outS[d,j] = Convert.ToString(func_out[index]);
                    index++;
                }
            }
            index = 0;
            temp_result +=  Arrayprinter.output_Array(func_outS, "After IP");
            for (int j = 0; j < 32; j++)
                S_out[j] = func_out[j];

            return temp_result;
        }



    }
}
