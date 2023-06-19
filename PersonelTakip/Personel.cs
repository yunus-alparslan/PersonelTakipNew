using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }


        SqlConnection dbbaglanti = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Table_PersonelNew;Integrated Security=True");



        void tablotemizle()
        {
            textBoxid.Text = "";
            textBoxad.Text = "";
            textBoxmaas.Text = "";
            textBoxsoyad.Text = "";
       
            comboBoxcinsiyet.Text = "Seçim Yapınız";
            comboBoxsehir.Text = "Seçim Yapınız";
            comboBoxdurum.Text = "Seçim Yapınız";
            maskedTextBoxtelefon.Text = "";
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }



        // SQL BAĞLANTI DATASET

    //    Table_PersonelNewDataSet.Table_PersonelDataTable tablo = new Table_PersonelNewDataSet.Table_PersonelDataTable();



        Table_PersonelNewDataSetTableAdapters.Table_PersonelTableAdapter tablo = new Table_PersonelNewDataSetTableAdapters.Table_PersonelTableAdapter();



        void listele()
        {
            dataGridView1.DataSource = tablo.GetData();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            listele();
          
        }

        private void button9_Click(object sender, EventArgs e)
        {

            tablo.EklePersonel(textBoxad.Text, textBoxsoyad.Text, comboBoxsehir.Text, comboBoxcinsiyet.Text, DateTime.Parse(dateTimePickertime.Text), short.Parse(textBoxmaas.Text), maskedTextBoxtelefon.Text, comboBoxdurum.Text);

            MessageBox.Show("Başarılı Şekilde Personel Eklendi","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxsehir.Text=  dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBoxcinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePickertime.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxmaas.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            maskedTextBoxtelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBoxdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dbbaglanti.Open();
            SqlCommand delete = new SqlCommand("Delete from Table_Personel Where Personelİd=@p1",dbbaglanti);
            delete.Parameters.AddWithValue("@p1", textBoxid.Text);
            delete.ExecuteNonQuery();
            dbbaglanti.Close();
            MessageBox.Show("Başarılı Şekilde Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            tablotemizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbbaglanti.Open();
            SqlCommand güncelle = new SqlCommand("Update Table_Personel Set Personelİsmi=@p1,PersonelSoyad=@p3,PersonelSehir=@p4,PersonelCinsiyet=@p5,PersonelBaslamaTarih=@p6,PersonelMaas=@p7,PersonelTelefon=@p8,PersonelDurum=@p9 where Personelİd=@p2", dbbaglanti);
            güncelle.Parameters.AddWithValue("@p1", textBoxad.Text);
            güncelle.Parameters.AddWithValue("@p3", textBoxsoyad.Text);
            güncelle.Parameters.AddWithValue("@p4", comboBoxsehir.Text);
            güncelle.Parameters.AddWithValue("@p5", comboBoxcinsiyet.Text);
            güncelle.Parameters.AddWithValue("@p6", DateTime.Parse(dateTimePickertime.Text));
            güncelle.Parameters.AddWithValue("@p7", textBoxmaas.Text);
            güncelle.Parameters.AddWithValue("@p8", maskedTextBoxtelefon.Text);
            güncelle.Parameters.AddWithValue("@p9", comboBoxdurum.Text);

            güncelle.Parameters.AddWithValue("@p2", textBoxid.Text);
            güncelle.ExecuteNonQuery();
            dbbaglanti.Close();
            MessageBox.Show("Başarılı Şekilde Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listele();
         
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Personel prs1 = new Personel();
            prs1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = tablo.PersonelAra(textBox5.Text);
                MessageBox.Show("Aradığınız  " + textBox5.Text +" Personel Bulundu ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {

             
                MessageBox.Show("Aradığınız  "+textBox5.Text+"Personel Bulunmadı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


          
        
        }
    }
}
