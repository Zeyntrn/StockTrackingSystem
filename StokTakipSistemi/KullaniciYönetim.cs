using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StokTakipSistemi
{
    public class KullaniciYönetim
    {
        private SqlConnection baglanti;

        public KullaniciYönetim()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }
        public class Kullanici
        {
           
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string KullaniciTuru { get; set; }
           public string KullaniciAd {  get; set; }
            public string Email { get; set; } 
            public string Sifre { get; set; }

            public int KullaniciID { get; set; }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Email formatı için regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                // Email formatını kontrol et
                if (!IsValidEmail(kullanici.Email))
                {
                    throw new Exception("Geçerli bir email adresi giriniz. Email adresinde '@' ve '.' içermelidir!");
                }
                string sorgu = "INSERT INTO Kullanicilar (Ad, Soyad, KullaniciTuru, KullaniciAdi, Email, Sifre) " +
                               "VALUES (@Ad, @Soyad, @KullaniciTuru, @KullaniciAdi, @Email, @Sifre)";
                using (SqlCommand komut = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    komut.Parameters.AddWithValue("@Ad", kullanici.Ad);
                    komut.Parameters.AddWithValue("@Soyad", kullanici.Soyad);
                    komut.Parameters.AddWithValue("@KullaniciTuru", kullanici.KullaniciTuru);
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAd);
                    komut.Parameters.AddWithValue("@Email", kullanici.Email);
                    komut.Parameters.AddWithValue("@Sifre", kullanici.Sifre);

                    SqlBaglanti.Instance.OpenConnection();

                    int sonuc = komut.ExecuteNonQuery();

                    return sonuc > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

         public bool KullaniciSil(int kullaniciID)
          {
              try
              {
                  string sorgu = "DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
                  SqlCommand komut = new SqlCommand(sorgu, baglanti);
                  komut.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                  SqlBaglanti.Instance.OpenConnection();

                  int sonuc = komut.ExecuteNonQuery();

                
                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız.");
                    return false;
                }

            }
            catch (Exception ex)
              {
                  MessageBox.Show("Kullanıcı silinirken hata oluştu: " + ex.Message);
                  return false;
              }
              finally
              {
                  SqlBaglanti.Instance.CloseConnection();
              }
          }

          public bool KullaniciGuncelle(Kullanici kullanici)
          {
              try
              {


                  // Öncelikle veritabanındaki mevcut verileri alıyoruz
                  string kontrolSorgusu = "SELECT Ad, Soyad, KullaniciTuru, KullaniciAdi, Email, Sifre FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
                using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgusu, baglanti)) 
                { 
                    kontrolKomut.Parameters.AddWithValue("@KullaniciID", kullanici.KullaniciID);
                    baglanti.Open();
                    SqlDataReader reader = kontrolKomut.ExecuteReader();
                   

                    if (reader.Read())
                    {
                        string mevcutAd = reader["Ad"].ToString();
                        string mevcutSoyad = reader["Soyad"].ToString();
                        string mevcutKullaniciTuru = reader["KullaniciTuru"].ToString();
                        string mevcutKullaniciAdi = reader["KullaniciAdi"].ToString();
                        string mevcutEmail = reader["Email"].ToString();
                        string mevcutSifre = reader["Sifre"].ToString();

                        // Eğer veriler değişmemişse işlem yapılmaz
                        if (mevcutAd == kullanici.Ad &&
                            mevcutSoyad == kullanici.Soyad &&
                            mevcutKullaniciTuru == kullanici.KullaniciTuru &&
                            mevcutKullaniciAdi == kullanici.KullaniciAd &&
                            mevcutEmail == kullanici.Email &&
                            mevcutSifre == kullanici.Sifre)
                        {
                            MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                            return false; // Değişiklik yapılmadığı için işlem tamamlanmaz
                        }
                    }
                    reader.Close();
                }
                // Email formatını kontrol et
                if (!IsValidEmail(kullanici.Email))
                {
                    throw new Exception("Geçerli bir email adresi giriniz. Email adresinde '@' ve '.' içermelidir!");
                }

                // Güncelleme sorgusu
                string sorgu = "UPDATE Kullanicilar SET Ad = @Ad, Soyad = @Soyad, KullaniciTuru = @KullaniciTuru, " +
                                 "KullaniciAdi = @KullaniciAdi, Email = @Email, Sifre = @Sifre WHERE KullaniciID = @KullaniciID";

                  SqlCommand komut = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection());

                  komut.Parameters.AddWithValue("@Ad", kullanici.Ad);
                  komut.Parameters.AddWithValue("@Soyad", kullanici.Soyad);
                  komut.Parameters.AddWithValue("@KullaniciTuru", kullanici.KullaniciTuru);
                  komut.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAd);
                  komut.Parameters.AddWithValue("@Email", kullanici.Email);
                  komut.Parameters.AddWithValue("@Sifre", kullanici.Sifre);
                  komut.Parameters.AddWithValue("@KullaniciID", kullanici.KullaniciID);

                  int sonuc = komut.ExecuteNonQuery();
                  return sonuc > 0; // Güncelleme başarılı mı?
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Bir hata oluştu: " + ex.Message);
                  return false;
              }
              finally
              {
                baglanti.Close();
              }
          }


          public DataTable KullaniciGetir()
          {
              try
              {
                  string sorgu = "SELECT * FROM Kullanicilar";
                  SqlDataAdapter veriler = new SqlDataAdapter(sorgu, baglanti);
                  DataTable tablo = new DataTable();
                  veriler.Fill(tablo);
                  return tablo;
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Kullanıcılar getirilirken hata oluştu: " + ex.Message);
                  return null;
              }
          }

          public DataTable KullaniciAra(string arama)
          {
            try
            {
                // Sorgu
                string sorgu = "SELECT * FROM Kullanicilar WHERE Ad LIKE @search OR Soyad LIKE @search";

                // SQL Komut nesnesi
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    // Parametre ekleme
                    komut.Parameters.AddWithValue("@search", "%" + arama + "%");

                    // Verileri doldurmak için adapter
                    using (SqlDataAdapter veriler = new SqlDataAdapter(komut))
                    {
                        DataTable tablo = new DataTable();
                        veriler.Fill(tablo); // Verileri tabloya doldur
                        return tablo; // Tabloyu geri döndür
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show("Arama işlemi sırasında hata oluştu: " + ex.Message);
                return null;
            }
        }
    } 
}

