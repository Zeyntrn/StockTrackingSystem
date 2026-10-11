using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace StokTakipSistemi
{
    
     
public class KullaniciGirisIslemleri
    {
        public static class KullaniciOturumu
        {
            public static int KullaniciID { get; set; }
            public static string KullaniciAdi { get; set; }
            public static string KullaniciTuru { get; set; }
        }




        // Kullanıcıyı doğrulama metodu
        public bool KullaniciDogrula(string kullaniciAdi, string sifre)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                string sorgu = "SELECT KullaniciID, KullaniciAdi, KullaniciTuru FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAd AND Sifre = @KullaniciSifre";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciAd", kullaniciAdi);
                komut.Parameters.AddWithValue("@KullaniciSifre", sifre);

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    KullaniciOturumu.KullaniciTuru = oku["KullaniciTuru"].ToString(); // Kullanıcı türünü sakla
                    KullaniciOturumu.KullaniciID = Convert.ToInt32(oku["KullaniciID"]);
                    KullaniciOturumu.KullaniciAdi = oku["KullaniciAdi"].ToString();
                    oku.Close();
                    return true;
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
            return false;
        }
    }
}

