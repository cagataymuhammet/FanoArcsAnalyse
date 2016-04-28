using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FanoOlusturanNoktalarAnaliz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void arkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql_query = "select N1,N2,N3,N4,N5,N6,N7 from tbl_fano_olmayan where BOYUT=7";
            get_data(sql_query);
        }


        static string sql_query;
        static string path = @"server=ASUS; database=db_fano;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(path);
        static SqlCommand command;
        static SqlDataAdapter sqladapter;
        static DataSet ds;



        public static void open_cnn()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public static void close_cnn()
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }


        void get_data(string sql)
        {
            ds = new DataSet();
            try
            {
                open_cnn();
                sqladapter = new SqlDataAdapter(sql, connection);
                sqladapter.Fill(ds);
                close_cnn();
            }
            catch (Exception)
            {
                
            }

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void tümüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql_query = "select * from tbl_fano_olmayan";
            get_data(sql_query);
        }

        private void arkToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            sql_query = "select N1,N2,N3,N4,N5,N6,N7,N8 from tbl_fano_olmayan where BOYUT=8";
            get_data(sql_query);
        }

        private void arkToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            sql_query = "select N1,N2,N3,N4,N5,N6,N7,N8,N9 from tbl_fano_olmayan where BOYUT=9";
            get_data(sql_query);
        }

        private void arkToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            sql_query = "select N1,N2,N3,N4,N5,N6 from tbl_fano_olmayan where BOYUT=6";
            get_data(sql_query);

        }

        private void tÜMÜBİÇİMLENMİŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql_query = "select BOYUT,N1,N2,N3,N4,N5,N6,N7,N8,N9,KIYAS from tbl_fano_olmayan";
            get_data(sql_query);
        }

        private void arkToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            sql_query = "select N1,N2,N3,N4,N5,N6,N7,N8,N9,N10 from tbl_fano_olmayan where BOYUT=10";
            get_data(sql_query);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
          
            this.WindowState = FormWindowState.Maximized;

            sql_query = "select * from tbl_fano_olmayan order by BOYUT";
            get_data(sql_query);
        }

        private void gERİToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();
        }

        private void eXCELEAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true; 

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            int StartCol = 1;

            int StartRow = 1; 

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {

                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                myRange.Value2 = dataGridView1.Columns[j].HeaderText;

            }

            StartRow++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                { 

                    try
                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                        myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;

                    }

                    catch
                    {

                       

                    }

                } 

            }
        }

        private void kAYITSAYISIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ROWS COUNT = " +dataGridView1.Rows.Count.ToString());
        }
    }
}
