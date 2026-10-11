using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
namespace StokTakipSistemi
{
    public class RaporIslemleri
    {
        private SqlConnection baglanti;
        public RaporIslemleri ()
        {
        baglanti = SqlBaglanti.Instance.GetConnection();
        }

        public class Satis
        {
            public int SatisID { get; set; }
            public string MusteriAdi { get; set; }
            public string PersonelAdi { get; set; }
            public string UrunAdi { get; set; }
            public DateTime SatisTarihi { get; set; }
            public decimal ToplamTutar { get; set; }
        }
        public class Personel
        {
            public string AdSoyad { get; set; }
            public int SatisSayisi { get; set; }
            public decimal ToplamTutar { get; set; }
        }

        public DataTable GetTumSatislar()
        {
            DataTable satislarTable = new DataTable();

            string query = @"
        SELECT 
            s.SatisID,
            CONCAT(m.Ad, ' ', m.Soyad) AS MusteriAdiSoyadi,
            CONCAT(k.Ad, ' ', k.Soyad) AS PersonelAdiSoyadi,
            u.UrunAdi,
            s.SatisTarihi,
            s.ToplamFiyat
        FROM Satislar s
        INNER JOIN Musteriler m ON s.MusteriID = m.MusteriID
        INNER JOIN Kullanicilar k ON s.KullaniciID = k.KullaniciID
        INNER JOIN Urunler u ON s.UrunID = u.UrunID;";

            try
            {
                using (SqlConnection connection = SqlBaglanti.Instance.GetConnection())
                {
                    SqlBaglanti.Instance.OpenConnection();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(satislarTable); // Veriyi DataTable içine doldur
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış bilgileri alınırken bir hata oluştu: " + ex.Message);
                Log.Error(ex, "Satış bilgileri alınırken hata oluştu.");
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return satislarTable;
        }

        public Personel GetEnCokSatanPersonel()
        {
            string query = @"
                SELECT TOP 1
                   CONCAT(k.Ad, ' ', k.Soyad) AS PersonelAdi,
                    COUNT(s.SatisID) AS SatisSayisi,
                    SUM(s.ToplamFiyat) AS ToplamFiyat
                FROM Satislar s
                INNER JOIN Kullanicilar k ON s.KullaniciID = k.KullaniciID
                GROUP BY k.Ad, k.Soyad
                ORDER BY SatisSayisi DESC;";

            try
            {
                using (SqlConnection connection = SqlBaglanti.Instance.GetConnection())
                {
                    SqlBaglanti.Instance.OpenConnection();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Personel
                        {
                            AdSoyad = reader["PersonelAdi"].ToString(),
                            SatisSayisi = Convert.ToInt32(reader["SatisSayisi"]),
                            ToplamTutar = Convert.ToDecimal(reader["ToplamFiyat"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("En çok satış yapan personel bilgisi alınırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return null;
        }

        public DataTable GetSatislarByTarih(DateTime secilenTarih)
        {
            DataTable satislarTable = new DataTable();

            string query = @"
        SELECT 
            s.SatisID,
            CONCAT(m.Ad, ' ', m.Soyad) AS MusteriAdiSoyadi,
            CONCAT(k.Ad, ' ', k.Soyad) AS PersonelAdiSoyadi,
            u.UrunAdi,
            s.SatisTarihi,
            s.ToplamFiyat
        FROM Satislar s
        INNER JOIN Musteriler m ON s.MusteriID = m.MusteriID
        INNER JOIN Kullanicilar k ON s.KullaniciID = k.KullaniciID
        INNER JOIN Urunler u ON s.UrunID = u.UrunID
        WHERE CAST(s.SatisTarihi AS DATE) = @Tarih;";

            try
            {
                using (SqlConnection connection = SqlBaglanti.Instance.GetConnection())
                {
                    SqlBaglanti.Instance.OpenConnection();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tarih", secilenTarih.Date); // Tarihi yalnızca gün olarak gönder

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(satislarTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış bilgileri alınırken bir hata oluştu: " + ex.Message);
                Log.Error(ex, "Tarihe göre satış bilgileri alınırken hata oluştu.");
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }

            return satislarTable;
        }

    }
}
