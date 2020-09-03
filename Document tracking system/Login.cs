using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class Login : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {            
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnteringDocumentRecord dlg1 = new EnteringDocumentRecord();
            dlg1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateUserAccount crt = new CreateUserAccount();
            crt.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Direct dr = new Direct();
            dr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool work = false;
            label4.Text = "";
            string query = @"select * from Account where username='" + textBox1.Text + "' and password='" + textBox2.Text + "' and position='site administrator'";
            ds.Clear();
            da.SelectCommand = new SqlCommand(query, db);
            db.Open();
            da.Fill(ds);
            db.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ManageUserAccount mg = new ManageUserAccount();
                this.Hide();
                mg.ShowDialog();
                this.Show();
                textBox1.Text = textBox2.Text = "";
                work = true;
            }
            else if (work == false)
            {
                query = @"select * from Account where username='" + textBox1.Text + "' and password='" + textBox2.Text + "' and position='secretary'";
                ds.Clear();
                da.SelectCommand = new SqlCommand(query, db);
                db.Open();
                da.Fill(ds);
                db.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SecretaryWindow sc = new SecretaryWindow();
                    this.Hide();
                    sc.ShowDialog();
                    this.Show();
                    textBox1.Text = textBox2.Text = "";
                    work = true;
                }
                else if (work == false)
                {
                    query = @"select * from Account where username='" + textBox1.Text + "' and password='" + textBox2.Text + "' and position='officer'";
                    ds.Clear();
                    da.SelectCommand = new SqlCommand(query, db);
                    db.Open();
                    da.Fill(ds);
                    db.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        OfficerWindow of = new OfficerWindow();
                        this.Hide();
                        of.ShowDialog();
                        this.Show();
                        textBox1.Text = textBox2.Text = "";
                        work = true;
                    }
                    else if (work == false)
                    {
                        query = @"select * from Account where username='" + textBox1.Text + "' and password='" + textBox2.Text + "' and position='post women'";
                        ds.Clear();
                        da.SelectCommand = new SqlCommand(query, db);
                        db.Open();
                        da.Fill(ds);
                        db.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            PostwomenWindow pw = new PostwomenWindow();
                            this.Hide();
                            pw.ShowDialog();
                            this.Show();
                            textBox1.Text = textBox2.Text = "";
                            work = true;
                        }
                        else
                        {
                            label4.Text = "warning : wrong user name or password";
                        }
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManageUserAccount mg = new ManageUserAccount();
            mg.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GuestWindow gs = new GuestWindow();
            this.Hide();
            gs.ShowDialog();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            GuestWindow gs = new GuestWindow();
            this.Hide();
            gs.ShowDialog();
            this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CreateUserAccount cr = new CreateUserAccount();
            cr.Show();
        }
    }
}
