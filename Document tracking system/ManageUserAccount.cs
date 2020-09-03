using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class ManageUserAccount : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr=null;
        DataSet ds = new DataSet();
        string query;
        public ManageUserAccount()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            query = @"select * from Account select * from Entering_document";
            ds.Clear();
            da.SelectCommand = new SqlCommand(query, db);
            db.Open();
            da.Fill(ds);
            db.Close();
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "username";
            listBox2.DataSource = ds.Tables[1];
            listBox2.DisplayMember = "doc_title";
        }

        private void ManageUserAccount_Load(object sender, EventArgs e)
        {
            query = @"select * from Account select * from Entering_document";
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
            ds.Clear();
            da.SelectCommand = new SqlCommand(query, db);
            db.Open();
            da.Fill(ds);
            db.Close();
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "username";
            listBox2.DataSource = ds.Tables[1];
            listBox2.DisplayMember = "doc_title";
        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserAccount crt = new CreateUserAccount();
            crt.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDocumentTrackingSystem abt = new AboutDocumentTrackingSystem();
            abt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateUserAccount crt = new CreateUserAccount();
            crt.ShowDialog();
            refresh();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\HP\\source\\repos\\Document tracking system\\Document tracking system\\bin\\Debug\\help.chm");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allAccountToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (allAccountToolStripMenuItem.Checked==true)
            {
                groupBox2.Visible = true;
            }
            else if (allAccountToolStripMenuItem.Checked == false)
            {
                groupBox2.Visible = false;
            }
        }

        private void allDocumentToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (allDocumentToolStripMenuItem.Checked == true)
            {
                groupBox1.Visible = true;
            }
            else if (allDocumentToolStripMenuItem.Checked == false)
            {
                groupBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string select = listBox1.GetItemText(listBox1.SelectedItem);
            query = @"delete from Account where username='" + select+ "'";
            if(MessageBox.Show("are you sure to delete this account", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Cancel)
            {
                da.DeleteCommand = new SqlCommand(query, db);
                db.Open();
                da.DeleteCommand.ExecuteNonQuery();
                db.Close();
                refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_account upa = new Update_account();
            if (upa.ShowDialog() == DialogResult.OK)
            {
                query = @"update Account set name='" + upa.data[0] + "',sex='" + upa.data[1] + "',username='" + upa.data[2] + "',password='" + upa.data[3] +
                    "',position='" + upa.data[4] + "',phone_number='" + upa.data[5] +"' where username='"+listBox1.GetItemText(listBox1.SelectedItem)+"'";
                ds.Clear();
                da.UpdateCommand = new SqlCommand(query, db);
                db.Open();
                da.UpdateCommand.ExecuteNonQuery();
                db.Close();
                MessageBox.Show(listBox1.GetItemText(listBox1.SelectedItem) + " has been successfuly updated", "Done");
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selection = listBox2.GetItemText(listBox2.SelectedItem);
            query = @"select * from Entering_document where doc_title='"+selection+"'";
            SqlCommand sc = new SqlCommand(query, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- "+dr["doc_id"].ToString()+"\n"
                           +"title -------------- " + dr["doc_title"].ToString()+"\n"
                           +"current office ----- " + dr["dest_office"].ToString() + "\n"
                           +"entering date ------ " + dr["entering_date"].ToString(), "status");
            db.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selection = listBox2.GetItemText(listBox2.SelectedItem);
            query = @"select * from Entering_document where doc_title='" + selection + "'";
            SqlCommand sc = new SqlCommand(query, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- " + dr["doc_id"].ToString() + "\n"
                           +"title -------------- " + dr["doc_title"].ToString() + "\n"
                           +"destination -------- " + dr["dest_office"].ToString() + "\n"
                           +"source ------------- " + dr["src_office"].ToString() + "\n"
                           +"entering date ------ " + dr["entering_date"].ToString(), "status");
            db.Close();

        }
    }
}
