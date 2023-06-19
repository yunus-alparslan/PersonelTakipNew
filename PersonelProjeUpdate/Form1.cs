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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// SQL BAĞLANTI GÖNDER 
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-0DOOTGM\\SQLEXPRESS01;Initial Catalog=Table_PersonelNew;Integrated Security=True");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            int code;
            Random KeyCode = new Random();
            code = KeyCode.Next(100, 500);
            SecCodetxt.Text = code.ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand girissorgula = new SqlCommand("Select * from Table_Admin where AdminKullanıcıAdı=@p1 and AdminSifre=@p2", bağlantı);
            girissorgula.Parameters.AddWithValue("@p1", textBox1.Text);
            girissorgula.Parameters.AddWithValue("@p2", textBox2.Text);

            SqlDataReader dr = girissorgula.ExecuteReader();

            if (dr.Read())
            {
                

                PanelPersonel prs = new PanelPersonel();
                prs.kullanicıadi = textBox1.Text;
                prs.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Şifre Yanlış Kanka");
            }
            bağlantı.Close();
        }
    }
}
