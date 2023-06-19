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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-M8M86O5\\SQLEXPRESS;Initial Catalog=PersonelTakipv1;Integrated Security=True");


        public string kullanıcıad;
        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmm = new SqlCommand("Select * from Table_Admin where AdminKullanıcıAdı=@p1 and AdminSifre=@p2", baglan);
            kmm.Parameters.AddWithValue("@p1", textBox1.Text);
            kmm.Parameters.AddWithValue("@p2", textBox2.Text);


            SqlDataReader red = kmm.ExecuteReader();

            if (red.Read())
            {
                MessageBox.Show("Giriş Başarılı Yönlendiriliyorsunuz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Admin form11 = new Admin();
                form11.kullanıcıad = textBox1.Text;
                form11.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış Lütfen Tekrar Deneyiniz ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            baglan.Close();
        }
    }
}
