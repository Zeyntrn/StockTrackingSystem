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
using Serilog;
using static StokTakipSistemi.KullaniciYönetim;
using System.Text.RegularExpressions;

namespace StokTakipSistemi
{
    public partial class SifreDegistir : Form
    {
        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string email = txtMail.Text;  // Kullanıcının e-posta adresi
                string yeniSifre = txtSifre.Text;  // Kullanıcının yeni şifresi

                // Email formatını kontrol et
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Geçerli bir email adresi giriniz. Email adresinde '@' ve '.' içermelidir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Geçersiz email formatı girildi: {Email}", email);
                    return;  // İşlem sonlandırılır
                }

                // SifreIslemleri sınıfını kullanarak şifreyi güncelle
                SifreIslemleri sifreIslemleri = new SifreIslemleri();
                bool isSuccess = sifreIslemleri.SifreGuncelle(email, yeniSifre);

                if (isSuccess)
                {
                    Log.Information("Şifre başarıyla güncellendi: {Email}", email);
                    MessageBox.Show("Şifreniz başarıyla güncellendi.");
                    KullaniciGiris giris = new KullaniciGiris();
                    giris.Show();
                    this.Close();
                }
                else
                {
                    Log.Warning("Şifre güncelleme başarısız: E-posta adresi bulunamadı: {Email}", email);
                    MessageBox.Show("Bu e-posta adresi veritabanında bulunmamaktadır.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Şifre güncelleme sırasında bir hata oluştu. E-posta: {Email}", txtMail.Text);
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciGiris giris = new KullaniciGiris();
            giris.Show();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Email formatı için regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}






