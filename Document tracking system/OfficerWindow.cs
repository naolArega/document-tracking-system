using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class OfficerWindow : Form
    {
        public OfficerWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Direct dr = new Direct();
            dr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateUserAccount cr = new CreateUserAccount();
            cr.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
