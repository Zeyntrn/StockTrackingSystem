using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static StokTakipSistemi.UrunIslemleri;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StokTakipSistemi
{
    public class UrunIslemleri
    {
        private SqlConnection baglanti;
        public UrunIslemleri()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }

        public class Urun
        {
            public int UrunID { get; set; }
            public string UrunAd { get; set; }
            public int AltKategoriID { get; set; }
            public decimal BirimFiyat { get; set; }
            public decimal AlisFiyat { get; set; }
            public string FotoAdres { get; set; }
        } 
        public DataTable AltKategoriler()
        {
           

            try
            {
                // Veritabanı bağlantısını aç

                string sorgu = "SELECT AltKategoriID, AltKategoriAdi FROM AltKategoriler";
                SqlDataAdapter veriler = new SqlDataAdapter(sorgu, baglanti);
                DataTable tablo = new DataTable();
                veriler.Fill(tablo);
                return tablo;

            }
              catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show("Alt kategoriler getirilirken hata oluştu: " + ex.Message);
            }

            return null;
        }
        public DataTable UrunleriGetir()
        {


            try
            {
                // Veritabanı bağlantısını aç

                string sorgu = @"
            SELECT 
                Urunler.UrunID, 
                Urunler.UrunAdi, 
                Urunler.BirimFiyati, 
                Urunler.AlisFiyati, 
                 Urunler.FotoYolu,
                AltKategoriler.AltKategoriAdi 
            FROM 
                Urunler
            INNER JOIN 
                AltKategoriler ON Urunler.AltKategoriID = AltKategoriler.AltKategoriID";
                SqlDataAdapter veriler = new SqlDataAdapter(sorgu, baglanti);
                DataTable tablo = new DataTable();
                veriler.Fill(tablo);
                return tablo;

            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show("Alt kategoriler getirilirken hata oluştu: " + ex.Message);
            }

            return null;
        }
        public bool UrunEkle (Urun urun )
        {
            try
            {
                // SQL sorgusu
                string sorgu = @"
        INSERT INTO Urunler (AltKategoriID, UrunAdi, BirimFiyati, AlisFiyati, FotoYolu)
        VALUES (@AltKategoriID, @UrunAdi, @BirimFiyati, @AlisFiyati, @FotoYolu)";

                // SQL komutu
                using (SqlCommand komut = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    // Parametreleri ekleme
                    komut.Parameters.AddWithValue("@AltKategoriID", urun.AltKategoriID);
                    komut.Parameters.AddWithValue("@UrunAdi", urun.UrunAd);
                    komut.Parameters.AddWithValue("@BirimFiyati", urun.BirimFiyat);
                    komut.Parameters.AddWithValue("@AlisFiyati", urun.AlisFiyat);
                    komut.Parameters.AddWithValue("@FotoYolu", urun.FotoAdres);

                    // Bağlantıyı aç
                    SqlBaglanti.Instance.OpenConnection();

                    // Sorguyu çalıştır
                    int sonuc = komut.ExecuteNonQuery();

                    return sonuc > 0; // Satır etkilendiyse başarı
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                // Bağlantıyı kapat
                SqlBaglanti.Instance.CloseConnection();
            }

        }
        public bool UrunSil (int UrunID)
        {
            
            try
            {
                // Önce bağlantılı kayıtları sil
                string stokSilSorgu = "DELETE FROM Stoklar WHERE UrunID = @UrunID";
                SqlCommand stokKomut = new SqlCommand(stokSilSorgu, baglanti);
                stokKomut.Parameters.AddWithValue("@UrunID", UrunID);
                SqlBaglanti.Instance.OpenConnection();
                stokKomut.ExecuteNonQuery();

                string sorgu = "DELETE FROM Urunler WHERE UrunID = @UrunID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@UrunID", UrunID);
                SqlBaglanti.Instance.OpenConnection();


                // Sorguyu çalıştır ve etkilenen satır sayısını kontrol et
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
                MessageBox.Show("Ürün Silinirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
                
            }
        

        }
        public bool UrunGuncelle(Urun urun)
        {

            try
            {
                // Mevcut verileri veritabanından alıyoruz
                string selectQuery = "SELECT AltKategoriID, UrunAdi, BirimFiyati, AlisFiyati, FotoYolu FROM Urunler WHERE UrunID = @UrunID";

                using (SqlCommand selectCmd = new SqlCommand(selectQuery, baglanti))
                {
                    selectCmd.Parameters.AddWithValue("@UrunID", urun.UrunID);
                    baglanti.Open();

                    SqlDataReader reader = selectCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int mevcutAltKategoriID = Convert.ToInt32(reader["AltKategoriID"]);
                        string mevcutUrunAdi = reader["UrunAdi"].ToString();
                        decimal mevcutBirimFiyat = Convert.ToDecimal(reader["BirimFiyati"]);
                        decimal mevcutAlisFiyat = Convert.ToDecimal(reader["AlisFiyati"]);
                        string mevcutFotoYolu = reader["FotoYolu"].ToString();

                        // Gelen değerler ile mevcut değerleri karşılaştırıyoruz
                        if (mevcutAltKategoriID == urun.AltKategoriID &&
                            mevcutUrunAdi == urun.UrunAd &&
                            mevcutBirimFiyat == urun.BirimFiyat &&
                            mevcutAlisFiyat == urun.AlisFiyat &&
                            mevcutFotoYolu == urun.FotoAdres)
                        {
                            // Değişiklik yok, işlem yapılmıyor
                            MessageBox.Show("Hiçbir değişiklik yapılmadı.");
                            return false;
                        }
                    }
                    reader.Close();
                }

                // Eğer değişiklik varsa güncelleme sorgusu çalıştırılır
                string query = @"
        UPDATE Urunler 
        SET AltKategoriID = @AltKategoriID, 
            UrunAdi = @UrunAdi, 
            BirimFiyati = @BirimFiyati, 
            AlisFiyati = @AlisFiyati, 
            FotoYolu = @FotoYolu 
        WHERE UrunID = @UrunID";

                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@AltKategoriID", urun.AltKategoriID);
                    cmd.Parameters.AddWithValue("@UrunAdi", urun.UrunAd);
                    cmd.Parameters.AddWithValue("@BirimFiyati", urun.BirimFiyat);
                    cmd.Parameters.AddWithValue("@AlisFiyati", urun.AlisFiyat);
                    cmd.Parameters.AddWithValue("@FotoYolu", urun.FotoAdres);
                    cmd.Parameters.AddWithValue("@UrunID", urun.UrunID);

                    int sonuc = cmd.ExecuteNonQuery();
                    return sonuc > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }



        }

    }
}
