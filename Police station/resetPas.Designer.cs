namespace Police_station
{
    partial class resetPas
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
            this.label1 = new System.Windows.Forms.Label();
            this.newPas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oldPas = new System.Windows.Forms.TextBox();
            this.confirmPas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset your Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newPas
            // 
            this.newPas.Location = new System.Drawing.Point(148, 148);
            this.newPas.Name = "newPas";
            this.newPas.PasswordChar = '*';
            this.newPas.Size = new System.Drawing.Size(167, 22);
            this.newPas.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "New Password";
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.Lavender;
            this.submit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.submit.Location = new System.Drawing.Point(130, 252);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(92, 35);
            this.submit.TabIndex = 5;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Old Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(12, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Confirm Password";
            // 
            // oldPas
            // 
            this.oldPas.Location = new System.Drawing.Point(140, 99);
            this.oldPas.Name = "oldPas";
            this.oldPas.PasswordChar = '*';
            this.oldPas.Size = new System.Drawing.Size(162, 22);
            this.oldPas.TabIndex = 8;
            // 
            // confirmPas
            // 
            this.confirmPas.Location = new System.Drawing.Point(174, 200);
            this.confirmPas.Name = "confirmPas";
            this.confirmPas.PasswordChar = '*';
            this.confirmPas.Size = new System.Drawing.Size(156, 22);
            this.confirmPas.TabIndex = 9;
            // 
            // resetPas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.confirmPas);
            this.Controls.Add(this.oldPas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newPas);
            this.Controls.Add(this.label1);
            this.Name = "resetPas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.reset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newPas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox oldPas;
        private System.Windows.Forms.TextBox confirmPas;
    }
}