namespace Police_station
{
    partial class Login
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
            this.submit = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.usernameDB = new System.Windows.Forms.TextBox();
            this.passwordDB = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.SystemColors.MenuBar;
            this.submit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.submit.Location = new System.Drawing.Point(263, 443);
            this.submit.Margin = new System.Windows.Forms.Padding(4);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(128, 48);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.SystemColors.MenuBar;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exit.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.exit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.exit.Location = new System.Drawing.Point(512, 443);
            this.exit.Margin = new System.Windows.Forms.Padding(4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(128, 48);
            this.exit.TabIndex = 1;
            this.exit.Text = "Cancel";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Cooper Black", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Lavender;
            this.Title.Location = new System.Drawing.Point(171, 38);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(858, 54);
            this.Title.TabIndex = 2;
            this.Title.Text = "Police Station Management System";
            this.Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Segoe UI Historic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.Gold;
            this.user.Location = new System.Drawing.Point(234, 233);
            this.user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(125, 31);
            this.user.TabIndex = 3;
            this.user.Text = "Username";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Segoe UI Historic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Gold;
            this.password.Location = new System.Drawing.Point(240, 340);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(119, 31);
            this.password.TabIndex = 4;
            this.password.Text = "Password";
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // usernameDB
            // 
            this.usernameDB.BackColor = System.Drawing.SystemColors.MenuBar;
            this.usernameDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameDB.Location = new System.Drawing.Point(446, 233);
            this.usernameDB.Margin = new System.Windows.Forms.Padding(4);
            this.usernameDB.Name = "usernameDB";
            this.usernameDB.Size = new System.Drawing.Size(303, 22);
            this.usernameDB.TabIndex = 5;
            this.usernameDB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordDB
            // 
            this.passwordDB.BackColor = System.Drawing.SystemColors.MenuBar;
            this.passwordDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordDB.Location = new System.Drawing.Point(446, 349);
            this.passwordDB.Margin = new System.Windows.Forms.Padding(4);
            this.passwordDB.Name = "passwordDB";
            this.passwordDB.PasswordChar = '*';
            this.passwordDB.Size = new System.Drawing.Size(303, 22);
            this.passwordDB.TabIndex = 6;
            this.passwordDB.TextChanged += new System.EventHandler(this.passwordDB_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Police_station.Properties.Resources.logoppppp_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(800, 154);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(365, 337);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1200, 600);  // Adjusted size for a more standard form
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.passwordDB);
            this.Controls.Add(this.usernameDB);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.submit);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox usernameDB;
        private System.Windows.Forms.TextBox passwordDB;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
