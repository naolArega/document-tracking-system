using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class EnteringDocumentRecord : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        public EnteringDocumentRecord()
        {
            InitializeComponent();
        }

        private void EnteringDocumentRecord_Load(object sender, EventArgs e)
        {
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox5.Text == "" || textBox7.Text == "" || comboBox2.Text == ""||comboBox1.Text=="")
            {
                label10.Text = "warning: fill required data";
            }
            else if (comboBox1.Text == comboBox2.Text)
            {
                label10.Text = "warning: destination office and source office can't be the same";
            }
            else
            {
                Random rnd = new Random();
                textBox1.Text = rnd.Next(0,9999).ToString();
                string sql;
                if (textBox2.Text == "")
                {
                    textBox2.Text = "no comment";
                    sql = @"insert into Entering_document values('" + textBox1.Text + "','" + textBox7.Text + "','"
                                                                          + comboBox1.Text + "','" + comboBox2.Text + "','"
                                                                          + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "','"
                                                                          + textBox2.Text+"')";
                }
                else
                {
                    sql = @"insert into Entering_document values('" + textBox1.Text + "','" + textBox7.Text + "','"
                                                                          + comboBox1.Text + "','" + comboBox2.Text + "','"
                                                                          + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "','"
                                                                          + textBox2.Text + "')";
                }
                da.InsertCommand = new SqlCommand(sql, db);
                db.Open();
                da.InsertCommand.ExecuteNonQuery();
                db.Close();
                button3.Enabled = true;
                label10.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("doc id:            "+textBox1.Text +"\n"+
                            "doc title:         "+textBox7.Text +"\n" +
                            "destination:       "+comboBox1.Text +"\n" +
                            "source:            "+comboBox2.Text +"\n" +
                            "refeer to:         "+textBox5.Text +"\n" +
                            "doc entering date: "+dateTimePicker1.Value.ToString() +"\n" +
                            "comment:           "+textBox2.Text,"preview");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox1.Text =
            textBox2.Text =
            textBox5.Text =
            textBox7.Text =
            comboBox1.Text =
            comboBox2.Text = "";

            button3.Enabled = false;
        }
    }
}
