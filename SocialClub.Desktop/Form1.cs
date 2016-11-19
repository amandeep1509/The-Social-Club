using SocialClub.Desktop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialClub.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
           if (uNametextBox.Text.Trim() == Settings.Default.Username && pwTextBox.Text.Trim() == Settings.Default.Password)
            {
                var frmManage = new Manage();
                frmManage.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(Resources.message1, Resources.message1, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
