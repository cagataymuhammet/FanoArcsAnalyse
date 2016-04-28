using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FanoOlusturanNoktalarAnaliz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                StreamReader SR = new StreamReader(f.OpenFile());
                listBox1.Items.Clear();
                string txt = SR.ReadLine();
                while (txt != null)
                {
                    listBox1.Items.Add(txt);
                    txt = SR.ReadLine();
                }
                SR.Close();

            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
            string row;
            progressBar1.Value = 0;
            for (int i = 0; i <listBox1.Items.Count-1; i++)
            {
             
                row = listBox1.Items[i].ToString();
                if (is_start_with_number(row))
                {
                    row = row.Replace("      ", "     "); // 6 >> 5
                    row = row.Replace("     ", "    ");  // 5 >> 4
                    row = row.Replace("    ", "   ");  // 4 >> 3
                    row = row.Replace("   ", "  ");  // 3 >> 2
                    row = row.Replace("  ", " ");  // 2 >> 1
                    row = row.Replace(" ", "-");  // 1 >>-
                    if (row.EndsWith("-"))
                    {
                        row = row.Remove(row.Length - 1);
                    }

                    string[] array = row.Split('-');
                    int[] int_array = Array.ConvertAll(array, int.Parse);
                    Array.Sort(int_array);
                    row = "";
                    for (int j = 0; j <int_array.Length; j++)
                    {
                        row = row + int_array[j] + "-";
                    }

                    if (row.EndsWith("-"))
                    {
                        row = row.Remove(row.Length - 1);
                    }

                    if(!is_inserted(row))
                    {
                         insert_to_database(int_array,row);
                    }

                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 1;
                    }
                    else
                    {
                        progressBar1.Value = 100;
                        progressBar1.Value = 0;
                    }
                }
            }
            progressBar1.Value = 100;
            MessageBox.Show("Compoleted...");
        }

        bool is_start_with_number(string satir)
        {
            bool result = false;
            try
            {
                string firs_char = satir.Substring(0, 1);
                Convert.ToInt16(firs_char);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        static string sql_querty;
        static string path = @"server=ASUS; database=db_fano;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(path);
        static SqlCommand sqlcommand;
        static SqlDataAdapter sqladapter;
        static DataSet ds;


        public static void open_cnn()
        {
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public static void cloas_cnn()
        {
            if (connection.State == ConnectionState.Open) connection.Close();
        }


        bool insert_to_database(int[] dizi, string kiyas_cumlesi)
        {
            open_cnn();
            bool durum = false;
            try
            {
                if (dizi.Length == 5)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5)  values (@B,@K,@N1,@N2,@N3,@N4,@N5)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                else if (dizi.Length == 6)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                else if (dizi.Length == 7)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6,N7)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6,@N7)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.Parameters.AddWithValue("@N7", dizi[6]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                else if (dizi.Length == 8)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6,N7,N8)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6,@N7,@N8)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.Parameters.AddWithValue("@N7", dizi[6]);
                    sqlcommand.Parameters.AddWithValue("@N8", dizi[7]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                else if (dizi.Length == 9)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6,N7,N8,N9)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6,@N7,@N8,@N9)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.Parameters.AddWithValue("@N7", dizi[6]);
                    sqlcommand.Parameters.AddWithValue("@N8", dizi[7]);
                    sqlcommand.Parameters.AddWithValue("@N9", dizi[8]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;

                }
                else if (dizi.Length == 10)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6,@N7,@N8,@N9,@N10)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.Parameters.AddWithValue("@N7", dizi[6]);
                    sqlcommand.Parameters.AddWithValue("@N8", dizi[7]);
                    sqlcommand.Parameters.AddWithValue("@N9", dizi[8]);
                    sqlcommand.Parameters.AddWithValue("@N10", dizi[9]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                else if (dizi.Length == 11)
                {
                    sql_querty = "insert into tbl_fano_olmayan(BOYUT,KIYAS,N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,N11)  values (@B,@K,@N1,@N2,@N3,@N4,@N5,@N6,@N7,@N8,@N9,@N10,@N11)";
                    sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sql_querty;
                    sqlcommand.Parameters.AddWithValue("@B", dizi.Length);
                    sqlcommand.Parameters.AddWithValue("@K", kiyas_cumlesi);
                    sqlcommand.Parameters.AddWithValue("@N1", dizi[0]);
                    sqlcommand.Parameters.AddWithValue("@N2", dizi[1]);
                    sqlcommand.Parameters.AddWithValue("@N3", dizi[2]);
                    sqlcommand.Parameters.AddWithValue("@N4", dizi[3]);
                    sqlcommand.Parameters.AddWithValue("@N5", dizi[4]);
                    sqlcommand.Parameters.AddWithValue("@N6", dizi[5]);
                    sqlcommand.Parameters.AddWithValue("@N7", dizi[6]);
                    sqlcommand.Parameters.AddWithValue("@N8", dizi[7]);
                    sqlcommand.Parameters.AddWithValue("@N9", dizi[8]);
                    sqlcommand.Parameters.AddWithValue("@N10", dizi[9]);
                    sqlcommand.Parameters.AddWithValue("@N11", dizi[10]);
                    sqlcommand.ExecuteNonQuery();
                    cloas_cnn();
                    durum = true;
                }
                cloas_cnn();
            }
            catch (Exception ex)
            {
                listBox2.Items.Add("hata " + ex.ToString());
                durum = false;
            }
            return durum;
        }


        bool is_inserted(string kiyas)
        {

            bool result = false;
            try
            {
                open_cnn();
                sql_querty = "Select * From tbl_fano_olmayan where KIYAS='" + kiyas + "'";
                sqladapter = new SqlDataAdapter(sql_querty, connection);
                ds = new DataSet();
                sqladapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = true;
                }
                cloas_cnn();
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();

        }
    }
}
