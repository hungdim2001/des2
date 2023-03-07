using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ma_Hoa
{
    public partial class Form1 : Form
    {
        encrypt en;

        public string plaintext = "";
        string Keyword = "";
        //private string fina;

        public Form1()
        {
            InitializeComponent();
            // setup();
        }
        public void setup()
        {
          
            TB_output.Text = "";
          
            TB_ma_hoa.Text = "";
            TB_Giai_ma.Text = "";
            TB_input.Text = "";
            TB_output.Text = "";
            TB_key.Text = "";
        }
        private void Des_encrypt_Click(object sender, EventArgs e)
        {
           // setup();
            Keyword += "keyword:" + TB_key + "\r\n";
            plaintext += "PlainText:" + TB_input + "\r\n";
            en = new encrypt(TB_input.Text, TB_key.Text);
            TB_output.Text += en.DoEncryption();
            // TB_ma_hoa.Text += en.getEncryption().ToString();
            TB_ma_hoa.Text += "\r\n";
            TB_ma_hoa.Text += binary_to_hex(en.getEncryption().ToString());
        }

        private void DES_decrypt_Click(object sender, EventArgs e)
        {
            
            TB_output.Text= en.DoDecryption();
            TB_Giai_ma.Text +=  binary_to_hex( en.getBinDec().ToString()) + "\r\n" + en.getDecryption();

        }
        public string binary_to_hex(string result)
        {
            int dec;
            int index = 0;
            string Result = "";
            for(int i = 0; i < result.Length / 4; i++)
            {
                string temp = result.Substring(index, 4);
                dec = 0;
                int[] arr = new int[4];
                for(int j = 0; j < temp.Length; j++)
                {
                    arr[j] = Int32.Parse(temp[j].ToString());
                  
                }
                dec += arr[0] *8 + arr[1] * 4+ arr[2]*2;
                if (arr[3] == 1)
                    dec += 1;
                if (dec > 9)
                   switch (dec)
                    {
                        case 10: Result = Result + "a"; break;
                        case 11: Result = Result + "b"; break;
                        case 12: Result = Result + "c"; break;
                        case 13: Result = Result + "d"; break;
                        case 14: Result = Result + "e"; break;
                        case 15: Result = Result + "f"; break;
                    }
                
                else
                    Result = Result + dec.ToString();

                index += 4;

            }
           
            return Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setup();
        }

		private void TB_key_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
