namespace Ma_Hoa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.TB_input = new System.Windows.Forms.TextBox();
			this.lb_input = new System.Windows.Forms.Label();
			this.TB_output = new System.Windows.Forms.TextBox();
			this.lb_output = new System.Windows.Forms.Label();
			this.Des_encrypt = new System.Windows.Forms.Button();
			this.DES_decrypt = new System.Windows.Forms.Button();
			this.TB_key = new System.Windows.Forms.TextBox();
			this.lb_key = new System.Windows.Forms.Label();
			this.TB_ma_hoa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TB_Giai_ma = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TB_input
			// 
			this.TB_input.Location = new System.Drawing.Point(52, 98);
			this.TB_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TB_input.Multiline = true;
			this.TB_input.Name = "TB_input";
			this.TB_input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_input.Size = new System.Drawing.Size(632, 61);
			this.TB_input.TabIndex = 0;
			// 
			// lb_input
			// 
			this.lb_input.AutoSize = true;
			this.lb_input.Location = new System.Drawing.Point(48, 79);
			this.lb_input.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb_input.Name = "lb_input";
			this.lb_input.Size = new System.Drawing.Size(95, 16);
			this.lb_input.TabIndex = 1;
			this.lb_input.Text = "Chuỗi Văn Bản";
			// 
			// TB_output
			// 
			this.TB_output.Location = new System.Drawing.Point(52, 369);
			this.TB_output.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TB_output.Multiline = true;
			this.TB_output.Name = "TB_output";
			this.TB_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_output.Size = new System.Drawing.Size(632, 186);
			this.TB_output.TabIndex = 2;
			// 
			// lb_output
			// 
			this.lb_output.AutoSize = true;
			this.lb_output.Location = new System.Drawing.Point(55, 350);
			this.lb_output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb_output.Name = "lb_output";
			this.lb_output.Size = new System.Drawing.Size(114, 16);
			this.lb_output.TabIndex = 3;
			this.lb_output.Text = "Quá Trình Giải Mã";
			// 
			// Des_encrypt
			// 
			this.Des_encrypt.Location = new System.Drawing.Point(704, 198);
			this.Des_encrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Des_encrypt.Name = "Des_encrypt";
			this.Des_encrypt.Size = new System.Drawing.Size(100, 28);
			this.Des_encrypt.TabIndex = 4;
			this.Des_encrypt.Text = "Mã Hóa";
			this.Des_encrypt.UseVisualStyleBackColor = true;
			this.Des_encrypt.Click += new System.EventHandler(this.Des_encrypt_Click);
			// 
			// DES_decrypt
			// 
			this.DES_decrypt.Location = new System.Drawing.Point(705, 276);
			this.DES_decrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.DES_decrypt.Name = "DES_decrypt";
			this.DES_decrypt.Size = new System.Drawing.Size(100, 28);
			this.DES_decrypt.TabIndex = 5;
			this.DES_decrypt.Text = "Giải Mã";
			this.DES_decrypt.UseVisualStyleBackColor = true;
			this.DES_decrypt.Click += new System.EventHandler(this.DES_decrypt_Click);
			// 
			// TB_key
			// 
			this.TB_key.Location = new System.Drawing.Point(52, 46);
			this.TB_key.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TB_key.MaxLength = 8;
			this.TB_key.Multiline = true;
			this.TB_key.Name = "TB_key";
			this.TB_key.Size = new System.Drawing.Size(161, 29);
			this.TB_key.TabIndex = 6;
			this.TB_key.TextChanged += new System.EventHandler(this.TB_key_TextChanged);
			// 
			// lb_key
			// 
			this.lb_key.AutoSize = true;
			this.lb_key.Location = new System.Drawing.Point(48, 26);
			this.lb_key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lb_key.Name = "lb_key";
			this.lb_key.Size = new System.Drawing.Size(38, 16);
			this.lb_key.TabIndex = 7;
			this.lb_key.Text = "Khóa";
			// 
			// TB_ma_hoa
			// 
			this.TB_ma_hoa.Location = new System.Drawing.Point(52, 187);
			this.TB_ma_hoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TB_ma_hoa.Multiline = true;
			this.TB_ma_hoa.Name = "TB_ma_hoa";
			this.TB_ma_hoa.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_ma_hoa.Size = new System.Drawing.Size(632, 47);
			this.TB_ma_hoa.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(53, 164);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Chuỗi Mã Hóa";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(53, 242);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Chuỗi Giải Mã";
			// 
			// TB_Giai_ma
			// 
			this.TB_Giai_ma.Location = new System.Drawing.Point(52, 266);
			this.TB_Giai_ma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TB_Giai_ma.Multiline = true;
			this.TB_Giai_ma.Name = "TB_Giai_ma";
			this.TB_Giai_ma.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TB_Giai_ma.Size = new System.Drawing.Size(632, 47);
			this.TB_Giai_ma.TabIndex = 10;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(704, 350);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 12;
			this.button1.Text = "Xóa";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 571);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TB_Giai_ma);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TB_ma_hoa);
			this.Controls.Add(this.lb_key);
			this.Controls.Add(this.TB_key);
			this.Controls.Add(this.DES_decrypt);
			this.Controls.Add(this.Des_encrypt);
			this.Controls.Add(this.lb_output);
			this.Controls.Add(this.TB_output);
			this.Controls.Add(this.lb_input);
			this.Controls.Add(this.TB_input);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_input;
        private System.Windows.Forms.Label lb_input;
        private System.Windows.Forms.TextBox TB_output;
        private System.Windows.Forms.Label lb_output;
        private System.Windows.Forms.Button Des_encrypt;
        private System.Windows.Forms.Button DES_decrypt;
        private System.Windows.Forms.TextBox TB_key;
        private System.Windows.Forms.Label lb_key;
        private System.Windows.Forms.TextBox TB_ma_hoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Giai_ma;
        private System.Windows.Forms.Button button1;
    }
}

