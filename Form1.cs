using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kasir_XIRPL7_CharelMeysyanti
{
    public partial class Form1 : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-90TVCGA3\CHARELMEY;Initial Catalog=Dbkasir;Integrated Security=True");
        SqlCommand mycommand = new SqlCommand();
        SqlDataAdapter myadapter = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
            Bersihkan();
            readdata();
        }

        void Bersihkan() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }

        void readdata(){
            try
            {
                mycommand.Connection = koneksi;
                myadapter.SelectCommand = mycommand;
                mycommand.CommandText = "select * from Table_Barang";
                DataSet ds = new DataSet();
                if (myadapter.Fill(ds, "Table_Barang") > 0){
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Table_Barang";
                }
                koneksi.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" ||textBox4.Text.Trim() == "" ||textBox5.Text.Trim() == "" ||textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi setiap kolom yang tersedia terlebih dahulu");
            }
            else
            {
                try{
                    mycommand.Connection = koneksi;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "INSERT INTO TABLE_BARANG VALUES ('"+textBox1.Text+ "', '"+textBox2.Text+ "', '"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+ "','"+textBox6.Text+"')";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0){
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Data berhasil di input");
                        readdata();
                        Bersihkan();
                    koneksi.Close();
                }
                catch (Exception ){
                    MessageBox.Show("Data gagal di input");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi setiap kolom yang tersedia terlebih dahulu");
            }
            else
            {
                try
                {
                    mycommand.Connection = koneksi;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "UPDATE Table_Barang SET KodeBarang= ' " + textBox1.Text + "' ,NamaBarang='" + textBox2.Text + "', HargaJual='" + textBox3.Text + "', HargaBeli='" + textBox4.Text + "', JumlahBarang='" + textBox5.Text + "', SatuanBarang='" + textBox6.Text + "'where KodeBarang= '" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0){
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Update Data berhasil!");
                        readdata();
                        Bersihkan();
                    koneksi.Close();
                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus " + textBox2.Text + "?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    mycommand.Connection = koneksi;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "DELETE FROM Table_Barang where KodeBarang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "Table_Barang") > 0) {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Table_Barang";
                    }
                    MessageBox.Show("Hapus Data Berhasil");
                    readdata();
                    Bersihkan();
                    koneksi.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                textBox3.Text = row.Cells["HargaJual"].Value.ToString();
                textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
                textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
