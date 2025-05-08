namespace Police_station
{
    partial class Polices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editDB = new System.Windows.Forms.Button();
            this.policesView = new Guna.UI.WinForms.GunaDataGridView();
            this.deleteDB = new System.Windows.Forms.Button();
            this.recordDB = new System.Windows.Forms.Button();
            this.passwordDB = new System.Windows.Forms.TextBox();
            this.phoneDB = new System.Windows.Forms.TextBox();
            this.addressDB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nameDB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.roleDB = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.policesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.MidnightBlue;
            this.label7.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(45, 436);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 32);
            this.label7.TabIndex = 14;
            this.label7.Text = "Logout";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(58, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 32);
            this.label6.TabIndex = 13;
            this.label6.Text = "Forensics";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(64, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cases";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(62, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Criminals";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(53, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Admin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 99);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 53);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(19, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.editDB);
            this.panel1.Controls.Add(this.policesView);
            this.panel1.Controls.Add(this.deleteDB);
            this.panel1.Controls.Add(this.recordDB);
            this.panel1.Controls.Add(this.passwordDB);
            this.panel1.Controls.Add(this.phoneDB);
            this.panel1.Controls.Add(this.addressDB);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.nameDB);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.roleDB);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(217, -34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 657);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // editDB
            // 
            this.editDB.BackColor = System.Drawing.SystemColors.Control;
            this.editDB.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.editDB.Location = new System.Drawing.Point(287, 191);
            this.editDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editDB.Name = "editDB";
            this.editDB.Size = new System.Drawing.Size(76, 26);
            this.editDB.TabIndex = 14;
            this.editDB.Text = "Edit";
            this.editDB.UseVisualStyleBackColor = false;
            this.editDB.Click += new System.EventHandler(this.editDB_Click);
            // 
            // policesView
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.policesView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.policesView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.policesView.BackgroundColor = System.Drawing.Color.White;
            this.policesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.policesView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.policesView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.policesView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.policesView.ColumnHeadersHeight = 4;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.policesView.DefaultCellStyle = dataGridViewCellStyle6;
            this.policesView.EnableHeadersVisualStyles = false;
            this.policesView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.policesView.Location = new System.Drawing.Point(31, 258);
            this.policesView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.policesView.Name = "policesView";
            this.policesView.RowHeadersVisible = false;
            this.policesView.RowHeadersWidth = 51;
            this.policesView.RowTemplate.Height = 24;
            this.policesView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.policesView.Size = new System.Drawing.Size(767, 326);
            this.policesView.TabIndex = 13;
            this.policesView.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.policesView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.policesView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.policesView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.policesView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.policesView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.policesView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.policesView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.policesView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.policesView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.policesView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.policesView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.policesView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.policesView.ThemeStyle.HeaderStyle.Height = 4;
            this.policesView.ThemeStyle.ReadOnly = false;
            this.policesView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.policesView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.policesView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.policesView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.policesView.ThemeStyle.RowsStyle.Height = 24;
            this.policesView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.policesView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.policesView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gunaDataGridView1_CellContentClick);
            // 
            // deleteDB
            // 
            this.deleteDB.BackColor = System.Drawing.SystemColors.Control;
            this.deleteDB.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.deleteDB.Location = new System.Drawing.Point(409, 191);
            this.deleteDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteDB.Name = "deleteDB";
            this.deleteDB.Size = new System.Drawing.Size(77, 26);
            this.deleteDB.TabIndex = 12;
            this.deleteDB.Text = "Delete";
            this.deleteDB.UseVisualStyleBackColor = false;
            this.deleteDB.Click += new System.EventHandler(this.deleteDB_Click);
            // 
            // recordDB
            // 
            this.recordDB.BackColor = System.Drawing.SystemColors.Control;
            this.recordDB.Font = new System.Drawing.Font("Californian FB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordDB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.recordDB.Location = new System.Drawing.Point(171, 191);
            this.recordDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recordDB.Name = "recordDB";
            this.recordDB.Size = new System.Drawing.Size(76, 26);
            this.recordDB.TabIndex = 10;
            this.recordDB.Text = "Record";
            this.recordDB.UseVisualStyleBackColor = false;
            this.recordDB.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwordDB
            // 
            this.passwordDB.Location = new System.Drawing.Point(641, 191);
            this.passwordDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordDB.Name = "passwordDB";
            this.passwordDB.Size = new System.Drawing.Size(123, 22);
            this.passwordDB.TabIndex = 9;
            // 
            // phoneDB
            // 
            this.phoneDB.Location = new System.Drawing.Point(641, 114);
            this.phoneDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneDB.Name = "phoneDB";
            this.phoneDB.Size = new System.Drawing.Size(123, 22);
            this.phoneDB.TabIndex = 8;
            // 
            // addressDB
            // 
            this.addressDB.Location = new System.Drawing.Point(445, 114);
            this.addressDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressDB.Name = "addressDB";
            this.addressDB.Size = new System.Drawing.Size(123, 22);
            this.addressDB.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(640, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 23);
            this.label12.TabIndex = 6;
            this.label12.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(637, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "Phone ";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(441, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "Address";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // nameDB
            // 
            this.nameDB.Location = new System.Drawing.Point(257, 114);
            this.nameDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameDB.Name = "nameDB";
            this.nameDB.Size = new System.Drawing.Size(123, 22);
            this.nameDB.TabIndex = 3;
            this.nameDB.TextChanged += new System.EventHandler(this.nameDB_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(259, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Name";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // roleDB
            // 
            this.roleDB.FormattingEnabled = true;
            this.roleDB.Items.AddRange(new object[] {
            "Admin",
            "Investigator",
            "Police Officer",
            "Forensic Expert"});
            this.roleDB.Location = new System.Drawing.Point(62, 112);
            this.roleDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roleDB.Name = "roleDB";
            this.roleDB.Size = new System.Drawing.Size(121, 24);
            this.roleDB.TabIndex = 1;
            this.roleDB.SelectedIndexChanged += new System.EventHandler(this.roleDB_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(64, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Role";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(23, 193);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(24, 257);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox4.Location = new System.Drawing.Point(24, 321);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            // 
            // Polices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 576);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Polices";
            this.Text = "Polices";
            this.Load += new System.EventHandler(this.Polices_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.policesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox roleDB;
        private System.Windows.Forms.TextBox nameDB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox passwordDB;
        private System.Windows.Forms.TextBox phoneDB;
        private System.Windows.Forms.TextBox addressDB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button recordDB;
        private System.Windows.Forms.Button deleteDB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private Guna.UI.WinForms.GunaDataGridView policesView;
        private System.Windows.Forms.Button editDB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}