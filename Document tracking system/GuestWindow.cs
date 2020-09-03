using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class GuestWindow : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string sql;
        public GuestWindow()
        {
            InitializeComponent();
        }

        private void GuestWindow_Load(object sender, EventArgs e)
        {
            db = new SqlConnection(@"Data Source=DESKTOP-VGSSBN5;Initial Catalog=document_tracking_db;Integrated Security=True");
            sql = @"select * from Entering_document";
            da.SelectCommand = new SqlCommand(sql, db);
            db.Open();
            da.Fill(ds);
            db.Close();
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "doc_title";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string selection = listBox1.GetItemText(listBox1.SelectedItem);
            sql = @"select * from Entering_document where doc_title='" + selection + "'";
            SqlCommand sc = new SqlCommand(sql, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- " + dr["doc_id"].ToString() + "\n"
                           +"title -------------- " + dr["doc_title"].ToString() + "\n"
                           +"destination -------- " + dr["dest_office"].ToString() + "\n"
                           +"source ------------- " + dr["src_office"].ToString()+"\n"
                           +"entering date ------ " + dr["entering_date"].ToString() , "history");
            db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string selection = listBox1.GetItemText(listBox1.SelectedItem);
            sql = @"select * from Entering_document where doc_title='" + selection + "'";
            SqlCommand sc = new SqlCommand(sql, db);
            db.Open();
            dr = sc.ExecuteReader();
            dr.Read();
            MessageBox.Show("document id -------- " + dr["doc_id"].ToString() + "\n"
                           +"title -------------- " + dr["doc_title"].ToString() + "\n"
                           +"current office ----- " + dr["dest_office"].ToString() + "\n"
                           +"entering date ------ " + dr["entering_date"].ToString(), "status");
            db.Close();
        }
    }
}
