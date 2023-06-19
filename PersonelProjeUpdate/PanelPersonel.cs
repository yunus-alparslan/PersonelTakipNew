using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelProjeUpdate
{
    public partial class PanelPersonel : Form
    {
        public PanelPersonel()
        {
            InitializeComponent();
        }

        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Table_PersonelNew;Integrated Security=True");


        public String kullanicıadi;
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            bağlantı.Open();
            SqlCommand toplapersonel = new SqlCommand("Select Count(*) Table_Personel ", bağlantı);
            SqlCommand ortalamamass = new SqlCommand("Select avg(PersonelMaas) from Table_Personel", bağlantı);
            SqlCommand mın = new SqlCommand("Select min(PersonelMaas) from Table_Personel", bağlantı);
            SqlCommand max = new SqlCommand("Select max(PersonelMaas) from Table_Personel", bağlantı);
            SqlCommand erkek = new SqlCommand("Select Count(*) from Table_Personel where PersonelCinsiyet='Erkek'", bağlantı);
            SqlCommand kadın = new SqlCommand("Select Count(*) from Table_Personel where PersonelCinsiyet='Kadın'", bağlantı);

            int kd = (int)kadın.ExecuteScalar();
            int erko = (int)erkek.ExecuteScalar();
            int ortalama = (int)ortalamamass.ExecuteScalar();
            int tplprs = (int)toplapersonel.ExecuteScalar();
            var ms = mın.ExecuteScalar();
            var mx = max.ExecuteScalar();



            labeltoplampersonel.Text = tplprs.ToString();
            labelortalamamaas.Text = ortalama.ToString();
            labeltoplamerkek.Text = erko.ToString();
            labeltoplamkadın.Text = kd.ToString();
            labelminumumaas.Text = ms.ToString();
            labelmaxmaas.Text = mx.ToString();
            bağlantı.Close();

            // button1.MouseClick = false;

   

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PanelPersonel_Load(object sender, EventArgs e)
        {
            label4.Text = kullanicıadi;

            bağlantı.Open();
            SqlCommand eşitle = new SqlCommand("Select * from Table_Admin where AdminKullanıcıAdı=@p1", bağlantı);
            eşitle.Parameters.AddWithValue("@p1", label4.Text);

            SqlDataReader tara = eşitle.ExecuteReader();

            while (tara.Read())
            {
                label5.Text = tara[1] + " " + tara[2].ToString();
                label8.Text = tara[5].ToString();
                label11.Text = tara[6].ToString();
            }
            bağlantı.Close();
        }
    }
}
