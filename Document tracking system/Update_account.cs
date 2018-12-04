using System;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class Update_account : Form
    {
        public Update_account()
        {
            InitializeComponent();
        }

        public string[] data;

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                comboBox1.Text=="" ||
                comboBox2.Text == "")
            {
                label8.Text = "warning: fill required data";
            }
            else
            {
                data = new string[] {textBox1.Text,
                                   comboBox1.Text,
                                   textBox2.Text,
                                   textBox3.Text,
                                   comboBox2.Text,
                                   textBox4.Text };
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
