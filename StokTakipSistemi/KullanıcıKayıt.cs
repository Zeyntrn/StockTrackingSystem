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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Serilog;


namespace StokTakipSistemi
{
    public partial class KullanıcıKayıt : Form
    {
        public KullanıcıKayıt()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcı bilgilerini al
                string ad = txtAd.Text;
                string soyad = txtSoyad.Text;
                string kullaniciTuru = cmbKullaniciTürü.Text;
                string kullaniciAdi = txtKullaniciAdi.Text;
                string email = txtMail.Text;
                string sifre = txtSifre.Text;

                // Kullanıcı nesnesi oluştur
                Kullanici yeniKullanici = new Kullanici(ad, soyad, kullaniciTuru, kullaniciAdi, email, sifre);

                // Kullanıcıyı kaydet
                KullaniciKayıtIslemleri kullaniciKayit = new KullaniciKayıtIslemleri();
                if (kullaniciKayit.KullaniciKaydet(yeniKullanici))
                {
                    Log.Information("Kullanıcı başarıyla kaydedildi: {KullaniciAdi}, {Email}", kullaniciAdi, email);
                    MessageBox.Show("Kayıt başarılı!");
                    KullaniciGiris yeniForm = new KullaniciGiris();
                    yeniForm.Show();
                    this.Close();
                }
                else
                {
                    Log.Warning("Kullanıcı kaydı başarısız oldu: {KullaniciAdi}, {Email}", kullaniciAdi, email);
                    MessageBox.Show("Kayıt başarısız.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı kaydı sırasında bir hata oluştu.");
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void KullanıcıKayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
