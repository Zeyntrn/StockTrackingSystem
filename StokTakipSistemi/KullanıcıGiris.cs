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
using System.Web;
using Serilog;



namespace StokTakipSistemi
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtkullaniciAd.Text;
            string sifre = txtkullaniciSifre.Text;

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                Log.Warning("Boş alan bırakıldı: Kullanıcı Adı veya Şifre eksik.");
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız!");
                return;
            }

            try
            {
                KullaniciGirisIslemleri kullanici = new KullaniciGirisIslemleri();
                if (kullanici.KullaniciDogrula(kullaniciAdi, sifre))
                {
                    string kullaniciTuru =KullaniciGirisIslemleri.KullaniciOturumu.KullaniciTuru;


                    Log.Information("Başarılı giriş: Kullanıcı Adı: {KullaniciAdi}, Tür: {KullaniciTuru}", kullaniciAdi, kullaniciTuru);
                    MessageBox.Show("Giriş Başarılı!");
                    Anasayfa yeniForm = new Anasayfa(kullaniciTuru);
                    yeniForm.Show();
                    this.Hide();
                }
                else
                {

                    Log.Warning("Hatalı giriş denemesi: Kullanıcı Adı: {KullaniciAdi}", kullaniciAdi);
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Giriş sırasında hata oluştu: Kullanıcı Adı: {KullaniciAdi}", kullaniciAdi);
                MessageBox.Show($"Giriş Yaparken Hata Oluştu: {ex.Message}");
            }
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            txtkullaniciSifre.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KullanıcıKayıt yeniForm = new KullanıcıKayıt();
            yeniForm.ShowDialog();  // showdialog kullanmamızın sebebi ekran açıldığında diğer ekran da işlemler yapamayalım diye

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreDegistir yeniForm = new SifreDegistir();
            yeniForm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
