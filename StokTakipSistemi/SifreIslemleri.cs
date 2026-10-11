using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    public class SifreIslemleri
    {
        public bool SifreGuncelle(string email, string yeniSifre)
        {
            try
            {
                SqlConnection baglanti = SqlBaglanti.Instance.GetConnection();
                SqlBaglanti.Instance.OpenConnection();

                // E-posta adresi veritabanında var mı kontrol et
                string sorgu = "Select COUNT(*) From Kullanicilar where Email = @Email";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@Email", email);

                int sayac = Convert.ToInt32(komut.ExecuteScalar());

                if (sayac > 0)
                {
                    // E-posta adresi bulunursa, şifreyi güncelle
                    string guncelleSifre = "UPDATE Kullanicilar SET Sifre = @Sifre WHERE Email = @Email";
                    SqlCommand guncelle = new SqlCommand(guncelleSifre, baglanti);
                    guncelle.Parameters.AddWithValue("@Sifre", yeniSifre);
                    guncelle.Parameters.AddWithValue("@Email", email);

                    guncelle.ExecuteNonQuery();  // Şifreyi güncelleme

                    return true;
                }
                else
                {
                    return false;  // E-posta adresi bulunamazsa false döner
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Şifre güncelleme işlemi sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
    }
}
