using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{

    public class StokTakip
    {
        private SqlConnection baglanti;


        public StokTakip()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();

        }

        // Ürünleri listeleyen metot
        public DataTable UrunleriGetir()
        {
            try
            {
                string sorgu = "SELECT UrunID, UrunAdi FROM Urunler";
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                DataTable urunTablosu = new DataTable();
                adapter.Fill(urunTablosu);
                return urunTablosu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler getirilirken hata oluştu: " + ex.Message);
                return null;
            }
        }
        public class Urun
        {
            public int UrunID { get; set; }
            public string UrunAd { get; set; }
            public int MevcutStok { get; set; }
            public string DepoAdi { get; set; }
            public int KullaniciID { get; set; }
            public DateTime SonGuncellemeTarihi { get; set; }

             public int MinimumStok { get; set; }

            public Urun(int urunID, string urunAd, string depoAdi, int mevcutStok, int kullaniciID, int minimumStok)
            {
                UrunID = urunID;
                UrunAd = urunAd;
                DepoAdi = depoAdi;
                MevcutStok = mevcutStok;
                KullaniciID = kullaniciID;
                MinimumStok = minimumStok;

                SonGuncellemeTarihi = DateTime.Now;

            }
        }

        public bool StokEkle(Urun urun)
        {
            try
            {
                // Öncelikle mevcut stoğu kontrol eden bir sorgu
                string kontrolSorgusu = @"
            SELECT MevcutStok, MinimumStokSeviyesi
            FROM Stoklar 
            WHERE UrunID = @UrunID AND DepoAdi = @DepoAdi;
        ";

                int mevcutStok = 0;
                int mevcutMinStok = 0;

                using (SqlCommand kontrolKomutu = new SqlCommand(kontrolSorgusu, baglanti))
                {
                    kontrolKomutu.Parameters.AddWithValue("@UrunID", urun.UrunID);
                    kontrolKomutu.Parameters.AddWithValue("@DepoAdi", urun.DepoAdi);
                    

                    baglanti.Open();
                    using (var reader = kontrolKomutu.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mevcutStok = reader.GetInt32(reader.GetOrdinal("MevcutStok")); // Mevcut stok miktarını al
                            mevcutMinStok = reader.GetInt32(reader.GetOrdinal("MinimumStokSeviyesi")); // Minimum stok seviyesini al
                        }
                    }
                    baglanti.Close();
                }

                string sorgu = string.Empty;

                // Sadece minimum stok seviyesi değişmişse, onu güncelle
                if (mevcutStok > 0)
                {
                    // Eğer minimum stok seviyesi değiştiyse, onu güncelle
                    if (mevcutMinStok != urun.MinimumStok)
                    {
                        sorgu = @"
                    UPDATE Stoklar 
                    SET MinimumStokSeviyesi = @MinStok,
                        SonGuncellemeTarihi = @SonGuncellemeTarihi,
                        KullaniciID = @KullaniciID
                    WHERE UrunID = @UrunID AND DepoAdi = @DepoAdi;
                ";
                    }
                    else
                    {
                        // Mevcut stok üzerinde bir değişiklik yapılması gerekiyorsa
                        sorgu = @"
        UPDATE Stoklar 
        SET MevcutStok = @MevcutStok,
            SonGuncellemeTarihi = @SonGuncellemeTarihi,
            KullaniciID = @KullaniciID
        WHERE UrunID = @UrunID AND DepoAdi = @DepoAdi;
        ";
                    }
                }
                else
                {
                    // Stok yoksa yeni kayıt ekle
                    sorgu = @"
                INSERT INTO Stoklar (UrunID, DepoAdi, MevcutStok, KullaniciID, SonGuncellemeTarihi, MinimumStokSeviyesi)
                VALUES (@UrunID, @DepoAdi, @MevcutStok, @KullaniciID, @SonGuncellemeTarihi, @MinStok);
            ";
                }

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunID", urun.UrunID);
                    komut.Parameters.AddWithValue("@DepoAdi", urun.DepoAdi);
                    komut.Parameters.AddWithValue("@SonGuncellemeTarihi", urun.SonGuncellemeTarihi);
                    komut.Parameters.AddWithValue("@KullaniciID", urun.KullaniciID);
                    // Eğer minimum stok seviyesi güncelleniyorsa, onu ekle
                    if (mevcutStok > 0 && mevcutMinStok != urun.MinimumStok)
                    {
                        komut.Parameters.AddWithValue("@MinStok", urun.MinimumStok);
                    }
                    else
                    {
                        // Yeni stok kaydına eklemek için mevcut stok miktarını da parametre olarak ekle
                        komut.Parameters.AddWithValue("@MevcutStok", urun.MevcutStok); // Yeni miktar
                     
                    }

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }

                MessageBox.Show("Stok başarıyla güncellendi!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok eklenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        public DataTable StoklariGetir()
        {
            try
            {
                string sorgu = @"
            SELECT 
                S.StokID, 
                U.UrunAdi, 
                S.DepoAdi, 
                S.MevcutStok, 
                S.MinimumStokSeviyesi, 
                S.SonGuncellemeTarihi, 
                K.Ad + ' ' + K.Soyad AS KullaniciAdSoyad
            FROM 
                Stoklar S
            JOIN 
                Urunler U ON S.UrunID = U.UrunID
            JOIN 
                Kullanicilar K ON S.KullaniciID = K.KullaniciID;
        ";

                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                DataTable stokTablosu = new DataTable();
                adapter.Fill(stokTablosu);
                return stokTablosu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stoklar getirilirken hata oluştu: " + ex.Message);
                return null;
            }
        }

    }
}


      
