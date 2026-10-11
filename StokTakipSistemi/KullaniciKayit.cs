using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    public class Kullanici
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciTuru { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }

        public Kullanici(string ad, string soyad, string kullaniciTuru, string kullaniciAdi, string email, string sifre)
        {
            Ad = ad;
            Soyad = soyad;
            KullaniciTuru = kullaniciTuru;
            KullaniciAdi = kullaniciAdi;
            Email = email;
            Sifre = sifre;
        }
    }

    public class KullaniciKayıtIslemleri
    {
        public bool KullaniciKaydet(Kullanici kullanici)
        {
            try
            {
                // Email formatını kontrol et
                if (!IsValidEmail(kullanici.Email))
                {
                    throw new Exception("Geçerli bir email adresi giriniz. Email adresinde '@' ve '.' içermelidir!");
                }
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciTuru, KullaniciAdi, Email, Sifre) " +
                               "VALUES (@Ad, @Soyad, @KullaniciTuru, @KullaniciAdi, @Email, @Sifre)";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Ad", kullanici.Ad);
                komut.Parameters.AddWithValue("@Soyad", kullanici.Soyad);
                komut.Parameters.AddWithValue("@KullaniciTuru", kullanici.KullaniciTuru);
                komut.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                komut.Parameters.AddWithValue("@Email", kullanici.Email);
                komut.Parameters.AddWithValue("@Sifre", kullanici.Sifre);

                int sonuc = komut.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı kaydı sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
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
