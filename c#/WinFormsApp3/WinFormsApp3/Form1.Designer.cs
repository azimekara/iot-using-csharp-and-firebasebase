
namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mod1combo = new System.Windows.Forms.ComboBox();
            this.btn = new System.Windows.Forms.Button();
            this.mod2combo = new System.Windows.Forms.ComboBox();
            this.rstbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mod3 = new System.Windows.Forms.Button();
            this.bluebar = new System.Windows.Forms.TrackBar();
            this.greenbar = new System.Windows.Forms.TrackBar();
            this.redbar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mod4red = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.mod4green = new System.Windows.Forms.Button();
            this.mod4blue = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bluebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mod1combo
            // 
            this.mod1combo.BackColor = System.Drawing.Color.White;
            this.mod1combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod1combo.FormattingEnabled = true;
            this.mod1combo.Location = new System.Drawing.Point(75, 79);
            this.mod1combo.Name = "mod1combo";
            this.mod1combo.Size = new System.Drawing.Size(151, 28);
            this.mod1combo.TabIndex = 2;
            this.mod1combo.SelectedIndexChanged += new System.EventHandler(this.mod1combo_SelectedIndexChanged);
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.White;
            this.btn.Location = new System.Drawing.Point(429, 362);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(168, 59);
            this.btn.TabIndex = 3;
            this.btn.Text = "Send";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // mod2combo
            // 
            this.mod2combo.BackColor = System.Drawing.Color.White;
            this.mod2combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod2combo.FormattingEnabled = true;
            this.mod2combo.Location = new System.Drawing.Point(274, 79);
            this.mod2combo.Name = "mod2combo";
            this.mod2combo.Size = new System.Drawing.Size(151, 28);
            this.mod2combo.TabIndex = 4;
            this.mod2combo.SelectedIndexChanged += new System.EventHandler(this.mod2combo_SelectedIndexChanged);
            // 
            // rstbtn
            // 
            this.rstbtn.BackColor = System.Drawing.Color.White;
            this.rstbtn.Location = new System.Drawing.Point(603, 362);
            this.rstbtn.Name = "rstbtn";
            this.rstbtn.Size = new System.Drawing.Size(172, 59);
            this.rstbtn.TabIndex = 5;
            this.rstbtn.Text = "Reset";
            this.rstbtn.UseVisualStyleBackColor = false;
            this.rstbtn.Click += new System.EventHandler(this.rstbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "MOD1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "MOD2";
            // 
            // mod3
            // 
            this.mod3.BackColor = System.Drawing.Color.White;
            this.mod3.Location = new System.Drawing.Point(531, 43);
            this.mod3.Name = "mod3";
            this.mod3.Size = new System.Drawing.Size(185, 29);
            this.mod3.TabIndex = 8;
            this.mod3.Text = "MOD3";
            this.mod3.UseVisualStyleBackColor = false;
            this.mod3.Click += new System.EventHandler(this.mod3_Click);
            // 
            // bluebar
            // 
            this.bluebar.Location = new System.Drawing.Point(518, 213);
            this.bluebar.Maximum = 255;
            this.bluebar.Minimum = 175;
            this.bluebar.Name = "bluebar";
            this.bluebar.Size = new System.Drawing.Size(206, 56);
            this.bluebar.TabIndex = 9;
            this.bluebar.Value = 175;
            this.bluebar.Scroll += new System.EventHandler(this.bluebar_Scroll);
            // 
            // greenbar
            // 
            this.greenbar.Location = new System.Drawing.Point(518, 151);
            this.greenbar.Maximum = 174;
            this.greenbar.Minimum = 93;
            this.greenbar.Name = "greenbar";
            this.greenbar.Size = new System.Drawing.Size(206, 56);
            this.greenbar.TabIndex = 10;
            this.greenbar.Value = 93;
            this.greenbar.Scroll += new System.EventHandler(this.greenbar_Scroll);
            // 
            // redbar
            // 
            this.redbar.BackColor = System.Drawing.Color.White;
            this.redbar.Location = new System.Drawing.Point(518, 89);
            this.redbar.Maximum = 92;
            this.redbar.Minimum = 11;
            this.redbar.Name = "redbar";
            this.redbar.Size = new System.Drawing.Size(206, 56);
            this.redbar.TabIndex = 11;
            this.redbar.Value = 11;
            this.redbar.Scroll += new System.EventHandler(this.redbar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(467, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(467, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ravie", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label5.Location = new System.Drawing.Point(467, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "B";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(557, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 43);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "7fdbc21ac05903100ed6362a67c58501.jpg");
            this.ımageList1.Images.SetKeyName(1, "10121616687154.jpg");
            this.ımageList1.Images.SetKeyName(2, "8820572979250_1571126119011.jpg");
            // 
            // mod4red
            // 
            this.mod4red.BackColor = System.Drawing.Color.White;
            this.mod4red.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mod4red.ImageIndex = 0;
            this.mod4red.ImageList = this.ımageList1;
            this.mod4red.Location = new System.Drawing.Point(74, 202);
            this.mod4red.Name = "mod4red";
            this.mod4red.Size = new System.Drawing.Size(185, 29);
            this.mod4red.TabIndex = 16;
            this.mod4red.Text = "Red";
            this.mod4red.UseVisualStyleBackColor = false;
            this.mod4red.Click += new System.EventHandler(this.mod4red_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "MOD4";
            // 
            // mod4green
            // 
            this.mod4green.BackColor = System.Drawing.Color.White;
            this.mod4green.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mod4green.ImageIndex = 1;
            this.mod4green.ImageList = this.ımageList1;
            this.mod4green.Location = new System.Drawing.Point(74, 262);
            this.mod4green.Name = "mod4green";
            this.mod4green.Size = new System.Drawing.Size(185, 29);
            this.mod4green.TabIndex = 18;
            this.mod4green.Text = "Green";
            this.mod4green.UseVisualStyleBackColor = false;
            this.mod4green.Click += new System.EventHandler(this.mod4green_Click);
            // 
            // mod4blue
            // 
            this.mod4blue.BackColor = System.Drawing.Color.White;
            this.mod4blue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mod4blue.ImageIndex = 2;
            this.mod4blue.ImageList = this.ımageList1;
            this.mod4blue.Location = new System.Drawing.Point(74, 324);
            this.mod4blue.Name = "mod4blue";
            this.mod4blue.Size = new System.Drawing.Size(185, 29);
            this.mod4blue.TabIndex = 19;
            this.mod4blue.Text = "Blue";
            this.mod4blue.UseVisualStyleBackColor = false;
            this.mod4blue.Click += new System.EventHandler(this.mod4blue_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.ImageIndex = 0;
            this.checkBox1.ImageList = this.ımageList1;
            this.checkBox1.Location = new System.Drawing.Point(309, 151);
            this.checkBox1.MaximumSize = new System.Drawing.Size(0, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(0, 31);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Red";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Location = new System.Drawing.Point(151, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 30);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.mod4blue);
            this.Controls.Add(this.mod4green);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mod4red);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.redbar);
            this.Controls.Add(this.greenbar);
            this.Controls.Add(this.bluebar);
            this.Controls.Add(this.mod3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rstbtn);
            this.Controls.Add(this.mod2combo);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.mod1combo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bluebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox mod1combo;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox mod2combo;
        private System.Windows.Forms.Button rstbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mod3;
        private System.Windows.Forms.TrackBar bluebar;
        private System.Windows.Forms.TrackBar redbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button mod4red;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button mod4green;
        private System.Windows.Forms.Button mod4blue;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TrackBar greenbar;
    }
}

