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

namespace Sifreleme_SQL_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DSQNOEI\SQLEXPRESS03;Initial Catalog=DbProjeler;Integrated Security=True");

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TblVeriler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DgvVeriler.DataSource= dt;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string Ad = TxtAd.Text;
            byte[] AdDizi = ASCIIEncoding.ASCII.GetBytes(Ad);
            string SifreliAd = Convert.ToBase64String(AdDizi);

            string Soyad = TxtSoyad.Text;
            byte[] SoyadDizi = ASCIIEncoding.ASCII.GetBytes(Soyad);
            string SifreliSoyad = Convert.ToBase64String(SoyadDizi);

            string Mail = TxtMail.Text;
            byte[] MailDizi = ASCIIEncoding.ASCII.GetBytes(Mail);
            string SifreliMail = Convert.ToBase64String(MailDizi);

            string Sifre = TxtSifre.Text;
            byte[] SifreDizi = ASCIIEncoding.ASCII.GetBytes(Sifre);
            string SifreliSifre = Convert.ToBase64String(SifreDizi);

            string HesapNo = TxtHesapNo.Text;
            byte[] HesapNoDizi = ASCIIEncoding.ASCII.GetBytes(HesapNo);
            string SifreliHesapNo = Convert.ToBase64String(HesapNoDizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblVeriler (Ad,Soyad,Mail,Sifre,HesapNo) values (@P1,@P2,@P3,@P4,@P5)", baglanti);
            komut.Parameters.AddWithValue("@P1", SifreliAd);
            komut.Parameters.AddWithValue("@P2", SifreliSoyad);
            komut.Parameters.AddWithValue("@P3", SifreliMail);
            komut.Parameters.AddWithValue("@P4", SifreliSifre);
            komut.Parameters.AddWithValue("@P5", SifreliHesapNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler Şifrelenerek Eklendi");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
