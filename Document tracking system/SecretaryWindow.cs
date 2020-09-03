using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class SecretaryWindow : Form
    {
        SqlConnection db;
        SqlDataAdapter da=new SqlDataAdapter();
        DataSet ds = new DataSet();
        public SecretaryWindow()
        {
            InitializeComponent();
        }

        private void SecretaryWindow_Load(object sender, EventArgs e)
        {
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
            string query = @"select * from Entering_document";
            ds.Clear();
            da.SelectCommand = new SqlCommand(query, db);
            db.Open();
            da.Fill(ds);
            db.Close();
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "doc_title";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDocumentTrackingSystem abt = new AboutDocumentTrackingSystem();
            abt.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserAccount usr = new CreateUserAccount();
            usr.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            EnteringDocumentRecord doc = new EnteringDocumentRecord();
            doc.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\HP\\source\\repos\\Document tracking system\\Document tracking system\\bin\\Debug\\help.chm");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string selection = listBox1.GetItemText(listBox1.SelectedItem);
            string query = @"select * from Entering_document where doc_title='" + selection + "'";
            SqlCommand sc = new SqlCommand(query, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- " + dr["doc_id"].ToString() + "\n"
                           +"title -------------- " + dr["doc_title"].ToString() + "\n"
                           +"current office ----- " + dr["dest_office"].ToString() + "\n"
                           +"entering date ------ " + dr["entering_date"].ToString(), "status");
            db.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string selection = listBox1.GetItemText(listBox1.SelectedItem);
            string query = @"select * from Entering_document where doc_title='" + selection + "'";
            SqlCommand sc = new SqlCommand(query, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- " + dr["doc_id"].ToString() + "\n"
                           +"title -------------- " + dr["doc_title"].ToString() + "\n"
                           +"destination -------- " + dr["dest_office"].ToString() + "\n"
                           +"source ------------- " + dr["src_office"].ToString() + "\n"
                           +"entering date ------ " + dr["entering_date"].ToString(), "history",MessageBoxButtons.OK,MessageBoxIcon.Information);
            db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string query = @"select count(doc_title) from Entering_document";
            SqlCommand sc = new SqlCommand(query, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            string docs=dr[0].ToString();
            dr.Close();
            query = @"select count(username) from Account";
            sc = new SqlCommand(query, db);
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("Total document: " + docs+"\n"
                           +"Total account: "+dr[0].ToString(), "report");
            db.Close();
        }
    }
}
