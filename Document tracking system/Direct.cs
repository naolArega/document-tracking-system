using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Document_tracking_system
{
    public partial class Direct : Form
    {
        SqlConnection db;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string sql;
        public Direct()
        {
            InitializeComponent();
        }

        private void Direct_Load(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {              
            sql = @"update Entering_document set src_office=dest_office , dest_office='" + comboBox1.Text +
                          "' where doc_title='"+listBox1.GetItemText(listBox1.SelectedItem)+"'";
            da.UpdateCommand = new SqlCommand(sql, db);
            db.Open();
            da.UpdateCommand.ExecuteNonQuery();
            db.Close();
            MessageBox.Show("document directed to "+comboBox1.Text,"notice");
        }
    }
}
