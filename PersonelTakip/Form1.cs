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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection dbbaglanti = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Table_PersonelNew;Integrated Security=True");

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            dbbaglanti.Open();
            SqlCommand toplamerkek = new SqlCommand("Select count (*) from Table_Personel where PersonelCinsiyet='Erkek'", dbbaglanti);
            SqlCommand toplamhesap = new SqlCommand("Select count (*) from Table_Personel", dbbaglanti);
            SqlCommand toplamkadın = new SqlCommand("Select count (*) from Table_Personel where PersonelCinsiyet='Kadın'", dbbaglanti);
        
            SqlCommand maxmaas = new SqlCommand("Select Max(PersonelMaas)  from Table_Personel", dbbaglanti);
            SqlCommand minmaas = new SqlCommand("Select Min(PersonelMaas)  from Table_Personel", dbbaglanti);
            SqlCommand ortalama = new SqlCommand("Select avg(PersonelMaas)  from Table_Personel", dbbaglanti);


            SqlCommand calisen = new SqlCommand("Select Count(*) from Table_Personel where PersonelDurum = 'Çalısıyor'", dbbaglanti);
            SqlCommand calimeyn = new SqlCommand("Select Count(*) from Table_Personel where PersonelDurum = 'Çalısmıyor'", dbbaglanti);

            int calimeynx = (int)calimeyn.ExecuteScalar();
            int toplmclsn = (int)calisen.ExecuteScalar();
            int toplam = (int)toplamhesap.ExecuteScalar();
            int erkek = (int)toplamerkek.ExecuteScalar();
            int kadın = (int)toplamkadın.ExecuteScalar();
    
            var maxi = maxmaas.ExecuteScalar();
            var min = minmaas.ExecuteScalar();
            int ortalamax = (int)ortalama.ExecuteScalar();

            labeltoplampersonel.Text = toplam.ToString();
            labelnull.Text = toplam.ToString();
            labelerkektoplam.Text = erkek.ToString();
            labelkadıntoplam.Text = kadın.ToString();
            label10.Text = toplmclsn.ToString();
            label12.Text = calimeynx.ToString();
            labelyuksekmaas.Text = maxi.ToString();
            labeldusukmaas.Text = min.ToString();
            labelortalama.Text = ortalamax.ToString();
            dbbaglanti.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Personel d = new Personel();
            d.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Personel prs1 = new Personel();
            prs1.Show();
            this.Hide();
        }
    }
}
