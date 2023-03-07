using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_Hoa
{
    class encrypt
    {

        private int ind = 0;
        private String binDec;
        private String binCi;
        private static Permutation p;
        private String keyWord;
        private String plainText;
        private int index_chooser = 0;
        private static int index = 0;
        private String cyphir;
        private static int[] reversedkey = new int[48];
        private static String key_reverse;
        private static Key_Gen key = new Key_Gen();
        private static int[] Block64 = new int[64];
        private static int[] num_Left = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
        private static int[] ch = new int[8];
        private static int[] newBlock64 = new int[64];
        private static int[] aft_XOR_fuc = new int[32];
        private static String[,] aft_XOR_fucS = new String[4, 8];
        private static int[] after_SBox = new int[32];
        private static int[] C_D = new int[56];
        private static int[] XOR_Out = new int[48];
        private static int[] key_in = new int[64];
        private static int[] final_key = new int[48];
        private static int[] key_out = new int[56];
        private static int[] Left = new int[32];
        private static int[] Right = new int[32];
        private static int[] Right_out = new int[48];
        private static int[] perm = new int[64];
        private static int[] perm_out = new int[64];
        private static int[] newBlock64_ = new int[64];
        private static int[] C = new int[28];
        private static int[] D = new int[28];
        private byte[][] block = new byte[8][];
        private String[,] blockS = new String[8, 8];
        private String finalEncry;
        private String finalDecry;
        private String Plain_Dec;
        private String[,] LeftS = new String[4, 8];
        private String[,] RightS = new String[4, 8];
        private String[,] XORS = new String[6, 8];
        private String[,] newBlock64_S = new String[8, 8];
        public string Result = "";
        public String getBinCi()
        {
            return binCi;
        }

        public String getDecryption()
        {
            return finalDecry;
        }

        public String getEncryption()
        {
            return finalEncry;
        }

        public String getBinDec()
        {
            return binDec;
        }

        public encrypt(String plain, String key)
        {
            plainText = plain;
            keyWord = key;
        }

        public String checkLenPlain(String plain)
        {
            // len;
            if (plain.Length % 8 != 0)
            {
                int len = 8 - plain.Length % 8;
                for (int i = 0; i < len; i++)
                    plain += "*";
                //plain = String.Concat(plain, "*");

            }
            else
                return plain;
            return plain;
        }

        public byte[] getBinaryBits(int ch)
        {
            byte[] bin = new byte[8];
            int tag = 1;
            for (int i = 0; i < 8; i++)
            {
                bin[7 - i] = (byte)((ch & ((tag << i))) >> i);
            }
            return bin;
        }

        public string doEncryptPlainText(String plain)
        {
            string temp1 = "";
            for (int i = 0; i < 8 && i < plain.Length; i++)
            {
                byte[] temp = getBinaryBits((char)plain[i]);
                //int count = getBinaryBits(((char)plain[i])).Length;
                //for (int j = 0; j < 8 && j<count;j++) ;
                block[i] = getBinaryBits((char)plain[i]);
            }


            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    perm[index] = (int)block[i][j];
                    blockS[i, j] = Convert.ToString((int)block[i][j]);
                    index++;
                }
            }

            temp1 += Arrayprinter.output_Array(blockS, "PlainText in binary");
            temp1 += "\r\n****************************************************************" + "\r\n";
            return temp1;
        }

        public string DoEncrpyt_keyword()
        {
            string temp_result = "";
            for (int i = 0; i < 8 && i < keyWord.Length; i++)
            {
                block[i] = getBinaryBits((char)keyWord[i]);
                for (int j = 0; j < 8; j++)
                {

                    blockS[i, j] = Convert.ToString((int)block[i][j]);


                }
                temp_result += "  ";
            }


            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    key_in[index] = (int)block[i][j];
                    index++;

                }
            }

            temp_result += Arrayprinter.output_Array(blockS, "KeyWord Text in Binary");
            temp_result += "\r\n****************************************************************" + '\n';
            return temp_result;
        }

        public string doSegmentation(int[] perm_out)
        {
            string temp1 = "";
            int index = 0;
            for (int i = 0; i < 32; i++)
                Left[i] = perm_out[i];

            for (int i = 32; i < 64; i++)
            {
                Right[index] = perm_out[i];

                index++;
            }
            index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    LeftS[i, j] = Convert.ToString(Left[index]);
                    RightS[i, j] = Convert.ToString(Right[index]);
                    index++;
                }
            }
            temp1 += Arrayprinter.output_Array(LeftS, "Left Part");
            temp1 += Arrayprinter.output_Array(RightS, "Right Part");
            return temp1;
        }

        public void XOR(int[] side1, int[] side2, int[] result)
        {
            int index = 0;
            for (int i = 0; i < side1.Length; i++)
            {
                if (side1[i] == side2[i])
                    result[index] = 0;
                else
                    result[index] = 1;
                index++;

            }
        }

        public void FillC_D()
        {
            int index = 28;
            for (int i = 0; i < 28; i++)
                C_D[i] = C[i];

            for (int i = 0; i < 28; i++)
            {
                C_D[index] = D[i];
                index++;
            }


        }

        public void contancate()
        {
            int index = 32;
            for (int i = 0; i < 32; i++)
                Block64[i] = Left[i];

            for (int i = 0; i < 32; i++)
            {
                Block64[index] = Right[i];
                index++;
            }
        }

        public string swap32()
        {
            string temp1 = "";
            int temp;
            for (int i = 0; i < 32; i++)
            {
                temp = Left[i];
                Left[i] = Right[i];
                Right[i] = temp;
            }
            ind = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    LeftS[i, j] = Convert.ToString(Left[ind]);
                    RightS[i, j] = Convert.ToString(Right[ind]);
                    ind++;
                }
            }
            temp1 += Arrayprinter.output_Array(LeftS, "Left Part");
            temp1 += Arrayprinter.output_Array(RightS, "Right Part");
            ind = 0;
            return temp1;
        }

        public static int[] getByteFromBits(int[] bits64)
        {
            // int ch[]=new int[8];
            int index = 0;
            //System.Console.WriteLine();
            for (int i = 0; i < 8; i++)
                for (int j = 1; j <= 8; j++)
                {
                    ch[i] += (int)Math.Pow(2, (8 - j)) * bits64[index];
                    index++;

                }

            return ch;
        }

        public string Chooser(int choice)
        {
            string temp_result = "";
            if (choice == 1)
            {
                temp_result += "\nBefore One left shift " + index;
                for (int j = 0; j < C.Length; j++)
                    temp_result += C[j];
                key.Do_OneLeftShitf(C, D);
                //temp_result += "\n";
                temp_result += "\r\nAfter One left shift " + index ;
                for (int j = 0; j < C.Length; j++)
                    temp_result += C[j];
            }

            else
            {

                for (int j = 0; j < C.Length; j++)
                    temp_result += C[j];

                key.Do_OneLeftShitf(C, D);
                key.Do_OneLeftShitf(C, D);
                temp_result += " LEFT= ";

                for (int j = 0; j < C.Length; j++)
                    temp_result += C[j];

                temp_result += " Right= ";

                for (int j = 0; j < D.Length; j++)
                    temp_result += D[j];

            }
            return temp_result;
        }

        public string DoDecryption()
        {
            string result = "";
            result += "************************DECIPHER***********************************" + "\r\n";
            int start = 0;

            int counter = 0;
            int end = 64;
            for (int f = 0; f < plainText.Length / 8; f++)
            {

                int Round = 1;
                for (int h = start; h < end; h++)
                {
                    //newBlock64_[counter] = Convert.ToInt32(finalEncry.Substring(h, h + 1));
                    //  newBlock64_[counter] = Convert.ToInt32(finalEncry.Substring(h, 1));
                    newBlock64_[counter] = int.Parse(finalEncry.Substring(h, 1));
                    counter++;
                }
                result += "*********Block Number *********" + (f + 1) + "\r\n";
                ind = 0;
                result += "*********Cipher Block In Round ********* " + Round + "\r\n";
                for (int d = 0; d < 8; d++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        newBlock64_S[d, j] = Convert.ToString(newBlock64[ind]);
                        ind++;
                    }
                }
                result+= Arrayprinter.output_Array(newBlock64_S, "Cipher Block");



                p = new Permutation();

                p.FillPermutation();//step1 from 2D to 1D
                result+= p.DoIP(newBlock64_, perm_out);
                doSegmentation(perm_out);

                int adder = 48;

                while (Round <= 16)
                {
                    result += "\r\n*********Round Number********* " + Round + "\r\n";
                    for (int i = 0; i < 48; i++)
                    {
                        //reversedkey[i] = Convert.ToInt32(key_reverse.Substring((key_reverse.Length - adder) + i, (key_reverse.Length - adder) + i + 1));
                        reversedkey[i] = Convert.ToInt32(key_reverse.Substring((key_reverse.Length - adder) + i, 1));

                    }

                    Console.WriteLine();

                    ESTable Etable = new ESTable();
                    Etable.FillETable();//step3 array from 2D to 1D
                    result+= Etable.DoETable(Right, Right_out);//step3
                    result += "\r\n*********Right Part XORED with Round Key********* " + Round + "\r\n";
                    XOR(Right_out, reversedkey, XOR_Out);//step1
                    ind = 0;
                    for (int g = 0; g < 6; g++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            XORS[g, j] = Convert.ToString(XOR_Out[ind]);
                            ind++;

                        }
                    }
                    result += Arrayprinter.output_Array(XORS, "XOR Result");
                    ind = 0;
                    S_Box sbox = new S_Box();

                    result+= sbox.Do_S_Box(XOR_Out, after_SBox);//step2 32bits - include permitation
                    //DesPanel.StepsText.append("*********Left Part XORED with Output Function in Round********* "+Round+'\n');
                    XOR(Left, after_SBox, aft_XOR_fuc);//XOR



                    for (int g = 0; g < 4; g++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            aft_XOR_fucS[g, j] = Convert.ToString(aft_XOR_fuc[ind]);
                            ind++;

                        }
                    }
                    ind = 0;
                    Result += Arrayprinter.output_Array(aft_XOR_fucS, "XOR Result");

                    adder = adder + 48;
                    Round++;
                    result += "*********Left=Right & Right=Left*********" + "\r\n";
                    for (int i = 0; i < 32; i++)
                    {
                        Left[i] = Right[i];
                        Right[i] = aft_XOR_fuc[i];
                    }


                }

                ind = 0;
                for (int g = 0; g < 4; g++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        LeftS[g, j] = Convert.ToString(Right[ind]);
                        RightS[g, j] = Convert.ToString(aft_XOR_fuc[ind]);
                        ind++;

                    }
                }
                result += Arrayprinter.output_Array(LeftS, "Left Part");
                result += Arrayprinter.output_Array(RightS, "Right Part");

                result += "********After Swap Operation********* " + "\r\n";
                result+= swap32();




                contancate();
                result += "\r\nBit Swap :\r\n";
                for (int i = 0; i < 64; i++)
                {
                    result+=Block64[i];
                }

                p.FillInversePermutation();//step1 from 2D to 1D
                result+= p.DoInverseIP(Block64, newBlock64);//step1 -array

                result += "\r\nThe decyption code: \r\n";
                for (int i = 0; i < 64; i++)
                {
                    if (binDec == null)
                        binDec = Convert.ToString(newBlock64[i]);
                    else
                        binDec += Convert.ToString(newBlock64[i]);
                    result += newBlock64[i];
                }
                Console.WriteLine(" ");
                ch = getByteFromBits(newBlock64);


                for (int i = 0; i < 8; i++)
                {
                    result +=(char)ch[i];
                    if (finalDecry == null)
                        finalDecry = Convert.ToString((char)ch[i]);
                    else
                        finalDecry += Convert.ToString((char)ch[i]);
                }

                for (int i = 0; i < 8; i++)
                    ch[i] = 0;
                start = end;
                end = end + 64;
                counter = 0;

            }

            return result;
        }

        public string DoEncryption()
        {
            string Result1 = "";
            Result1 += "************************CIPHER***********************************" + "\r\n";
            Result1+= DoEncrpyt_keyword();
            int start = 0;
            int end = 8;
            plainText = checkLenPlain(plainText);

            String temp;
            for (int f = 0; f < plainText.Length / 8; f++)
            {

                temp = plainText.Substring(start, end);



                Result1 += doEncryptPlainText(temp);


                Result1 += "\r\n" + "Original Message Code::" + "\r\n";
                for (int i = 0; i < 64; i++)
                {
                    if (binCi == null)
                        binCi = Convert.ToString(perm[i]);
                    else
                        binCi += Convert.ToString(perm[i]);
                    Result1 += perm[i];
                }
                int Round = 1;

                Result1 += "\r\n********* Block Number *********" + (f + 1) + "\r\n";
                
                Permutation p = new Permutation();
                p.FillPermutation();//step1 from 2D to 1D
                Result1+= p.DoIP(perm, perm_out);//step1 -array
                Result1+= doSegmentation(perm_out);//step2 to Left and Right
               
                key.FillPC_1();//step1 -array
            
                key.DoPC_1(key_in, key_out);//step1

                Result1 += key.DoSegementation(key_out, C, D);//step2

                while (Round <= 16)
                {
                   

                    int chooser = num_Left[index_chooser];
                    ESTable Etable = new ESTable();
                    Etable.FillETable();//step3 array from 2D to 1D
                    Result1 += Etable.DoETable(Right, Right_out);//step3

                    ////////////////////////////////////////////////////////////////////////
                    Console.WriteLine();
                    Result1 += Chooser(chooser);//step 3 - shift
                    Result1 += "\r\nchoose = " + chooser + "\r\n";
                    key.FillPC_2();//step4 array
                    FillC_D();//step4 contacnate 56bits
                    Result1 += "\n*********Key For Round Number*********  " + Round + " \r\n";
                    key.DoPC_2(C_D, final_key);//step4 here the key of Round 1
                    for (int i = 0; i < 48; i++)
                    {
                        if (key_reverse == null)
                            key_reverse = Convert.ToString(final_key[i]);
                        else
                            key_reverse += Convert.ToString(final_key[i]);

                    }


                    ////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////
                    Result1 += "*********Right Part XORED with Round Key********* " + Round + "\r\n";
                    XOR(Right_out, final_key, XOR_Out);//step1
                    ind = 0;
                    for (int g = 0; g < 6; g++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            XORS[g, j] = Convert.ToString(XOR_Out[ind]);
                            ind++;

                        }
                    }
                    ind = 0;

                    Result1 += Arrayprinter.output_Array(XORS, "XOR Result");
                    Result1 += "\r\n" + "XOR :";
                    for (int j = 0; j < 48; j++)
                    {
                        Result1 += XOR_Out[j];
                    }
                    S_Box sbox = new S_Box();

                    Result1 += sbox.Do_S_Box(XOR_Out, after_SBox);//step2 32bits - include permitation
                    Result1 += "\r\n" + "S - BOX :";
                    for (int j = 0; j < 32; j++)
                    {
                        Console.Write(after_SBox[j]);
                    }
                    Result1 += "\r\n" + " After XOR  :" + "\r\n";
                    Result1 += "*********Left Part XORED with Output Function in Round********* " + Round + "\r\n";
                    XOR(Left, after_SBox, aft_XOR_fuc);//XOR

                    //////////////

                    for (int g = 0; g < 4; g++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            aft_XOR_fucS[g, j] = Convert.ToString(aft_XOR_fuc[ind]);
                            ind++;

                        }
                    }
                    ind = 0;
                    Result1 += Arrayprinter.output_Array(aft_XOR_fucS, "XOR Result");

                    for (int j = 0; j < 32; j++)
                    {
                        Console.Write(aft_XOR_fuc[j]);
                    }


                    Round++;
                    index++;
                    index_chooser++;

                    Result1 += "\r\n" + "*********Left=Right & Right=Left*********" + "\r\n";
                    for (int i = 0; i < 32; i++)
                    {
                        Left[i] = Right[i];
                        Right[i] = aft_XOR_fuc[i];
                    }

                    ind = 0;
                    for (int g = 0; g < 4; g++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LeftS[g, j] = Convert.ToString(Right[ind]);
                            RightS[g, j] = Convert.ToString(aft_XOR_fuc[ind]);
                            ind++;

                        }
                    }
                    Result1 += Arrayprinter.output_Array(LeftS, "Left Part");
                    Result1 += Arrayprinter.output_Array(RightS, "Right Part");


                }

                Result1 += "\r\n" + "********After Swap Operation*********" + "\r\n";
                swap32();

                contancate();
                Result1 += "\r\n" + "Bit Swap :" + "\r\n";
                for (int i = 0; i < 64; i++)
                {
                    Result += Block64[i];
                }

                p.FillInversePermutation();//step1 from 2D to 1D
                Result1 += "\r\n" + "********* Inverse Permutation Operation in Round *********" + (f + 1) + "\r\n";
                p.DoInverseIP(Block64, newBlock64);//step1 -array
                Console.WriteLine(" ");
                Result1 += "\r\n" + "The Encyption code: " + "\r\n";
                for (int i = 0; i < newBlock64.Length; i++)
                {
                    Console.Write(newBlock64[i]);
                    if (finalEncry == null)
                        finalEncry = Convert.ToString(newBlock64[i]);
                    else
                        finalEncry += Convert.ToString(newBlock64[i]);

                }
                start = end;
                //  end = end + 8;
                index_chooser = 0;

            }
            Console.WriteLine("");
            Result1 += "\r\n" + "Final :" + finalEncry + "\r\n";
            return Result1;
        }

    }
}
