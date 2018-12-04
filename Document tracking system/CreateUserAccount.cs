using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class CreateUserAccount : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public CreateUserAccount()
        {
            InitializeComponent();
        }

        private void CreateUserAccount_Load(object sender, EventArgs e)
        {
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""||
               textBox7.Text!=""||
               comboBox2.Text!=""||
               textBox3.Text!=""||
               textBox4.Text!=""||
               comboBox1.Text!=""||
               textBox6.Text != "")
            {
                string sql = @"insert into Account values('" + textBox1.Text + " " + textBox7.Text + "','" + comboBox2.Text + "','" + textBox3.Text +
                    "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "')";
                ds.Clear();
                da.SelectCommand = new SqlCommand(sql, db);
                db.Open();
                da.Fill(ds);
                db.Close();
                MessageBox.Show("new account successfully created", "Account");
                textBox1.Text = textBox7.Text = comboBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = textBox6.Text = "";
            }
            else
            {
                label8.Text = "warning: fill required data";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
