namespace Police_station
{
    partial class criminal
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
            this.RecordBTN = new System.Windows.Forms.Button();
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.EditBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ActivitiesTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.CriminalsTB = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CriminalsTB)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecordBTN
            // 
            this.RecordBTN.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.RecordBTN.Location = new System.Drawing.Point(407, 162);
            this.RecordBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RecordBTN.Name = "RecordBTN";
            this.RecordBTN.Size = new System.Drawing.Size(75, 32);
            this.RecordBTN.TabIndex = 0;
            this.RecordBTN.Text = "Record";
            this.RecordBTN.UseVisualStyleBackColor = true;
            this.RecordBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddressTB
            // 
            this.AddressTB.Location = new System.Drawing.Point(325, 57);
            this.AddressTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddressTB.Multiline = true;
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.Size = new System.Drawing.Size(209, 56);
            this.AddressTB.TabIndex = 3;
            this.AddressTB.TextChanged += new System.EventHandler(this.AddressTB_TextChanged);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(197, 58);
            this.NameTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(103, 22);
            this.NameTB.TabIndex = 6;
            this.NameTB.TextChanged += new System.EventHandler(this.NameTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Manage criminals";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(323, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address";
            // 
            // CancelBTN
            // 
            this.CancelBTN.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.CancelBTN.Location = new System.Drawing.Point(488, 162);
            this.CancelBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 32);
            this.CancelBTN.TabIndex = 17;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // EditBTN
            // 
            this.EditBTN.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.EditBTN.Location = new System.Drawing.Point(325, 162);
            this.EditBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(75, 32);
            this.EditBTN.TabIndex = 18;
            this.EditBTN.Text = "Edit";
            this.EditBTN.UseVisualStyleBackColor = true;
            this.EditBTN.Click += new System.EventHandler(this.EditBTN_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(195, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Name";
            // 
            // ActivitiesTB
            // 
            this.ActivitiesTB.Location = new System.Drawing.Point(555, 57);
            this.ActivitiesTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ActivitiesTB.Multiline = true;
            this.ActivitiesTB.Name = "ActivitiesTB";
            this.ActivitiesTB.Size = new System.Drawing.Size(209, 100);
            this.ActivitiesTB.TabIndex = 20;
            this.ActivitiesTB.TextChanged += new System.EventHandler(this.ActivitiesTB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(552, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Activies Involved";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // CriminalsTB
            // 
            this.CriminalsTB.BackgroundColor = System.Drawing.Color.White;
            this.CriminalsTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CriminalsTB.Location = new System.Drawing.Point(168, 199);
            this.CriminalsTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CriminalsTB.Name = "CriminalsTB";
            this.CriminalsTB.RowHeadersWidth = 51;
            this.CriminalsTB.RowTemplate.Height = 24;
            this.CriminalsTB.Size = new System.Drawing.Size(620, 242);
            this.CriminalsTB.TabIndex = 22;
            this.CriminalsTB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 470);
            this.panel1.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(12, 354);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(127, 84);
            this.panel3.TabIndex = 35;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(13, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 34);
            this.button2.TabIndex = 38;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 36;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox4.Location = new System.Drawing.Point(13, 242);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(15, 186);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Californian FB", 14.6F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(38, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 29);
            this.label10.TabIndex = 30;
            this.label10.Text = "Forensics";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Californian FB", 15.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(53, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 31);
            this.label9.TabIndex = 29;
            this.label9.Text = "Cases";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(4, 123);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.MidnightBlue;
            this.label8.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(35, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 29);
            this.label8.TabIndex = 27;
            this.label8.Text = "Criminals";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(46, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 32);
            this.label7.TabIndex = 26;
            this.label7.Text = "Admin";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(8, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(3, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 39);
            this.panel2.TabIndex = 11;
            // 
            // criminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CriminalsTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ActivitiesTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EditBTN);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.AddressTB);
            this.Controls.Add(this.RecordBTN);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "criminal";
            this.Text = "criminal";
            this.Load += new System.EventHandler(this.criminal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CriminalsTB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecordBTN;
        private System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ActivitiesTB;
        private System.Windows.Forms.Label label3;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        //private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.DataGridView CriminalsTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}