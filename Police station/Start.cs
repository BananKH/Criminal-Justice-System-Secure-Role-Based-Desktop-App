using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_station
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            this.Click += new EventHandler(RedirectToLogin);
            RegisterClickEventForAllControls(this.Controls);
        }

        private void RegisterClickEventForAllControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click += new EventHandler(RedirectToLogin);
                if (control.HasChildren)
                {
                    RegisterClickEventForAllControls(control.Controls);
                }
            }
        }

        private void RedirectToLogin(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // You can also add specific code here if needed for pictureBox1.
        }
    }
}
