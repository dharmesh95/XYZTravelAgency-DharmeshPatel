using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XYZTravelAgency_DharmeshPatel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.MdiParent = this;
            registerForm.Show();
        }

        private void DisplayModifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayModifyForm displayModifyForm = new DisplayModifyForm();
            displayModifyForm.MdiParent = this;
            displayModifyForm.Show();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm();
            groupForm.MdiParent = this;
            groupForm.Show();
        }
    }
}
