using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static StokTakipSistemi.KullaniciYönetim;
using static StokTakipSistemi.MusteriIslemleri;

namespace StokTakipSistemi
{
    public class MusteriIslemleri
    {

        private SqlConnection baglanti;
        public MusteriIslemleri()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
            Urunler = new List<Urun>();
        }
        public List<Urun> Urunler { get; set; }

        public class SepetItem
        {
            public int UrunID { get; set; }
            public string UrunAdi { get; set; }
            public int Miktar { get; set; }
            public decimal BirimFiyat { get; set; }
            public decimal ToplamFiyat => Miktar * BirimFiyat;
        }
        public class Musteri
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }
            public int MusteriID { get; set; }

        }

        public class Satis
        {
            public int MusteriID { get; set; }
            public int UrunID { get; set; }
            public int KullaniciID { get; set; }
            public DateTime SatisTarihi { get; set; }
            public int SatisMiktari { get; set; }
            public decimal ToplamFiyat { get; set; }

            public decimal UrunFiyati { get; set; }
            public decimal ToplamTutar => SatisMiktari * UrunFiyati;
        }

        public class Urun
        {
            public string UrunAd { get; set; }
            public decimal BirimFiyat { get; set; }
            public int Adet { get; set; }

            // Parametreli constructor
            public Urun(string urunAd, decimal birimFiyat, int adet)
            {
                UrunAd = urunAd;
                BirimFiyat = birimFiyat;
                Adet = adet;
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

        public bool MusteriEkle(Musteri musteri)
        {
            if (MusteriVarMi(musteri))
            {
                MessageBox.Show("Bu müşteri zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            try
            {
                if (!IsValidEmail(musteri.Email))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string sorgu = "INSERT INTO Musteriler (Ad, Soyad, Telefon, Email) " +
                               "VALUES (@Ad, @Soyad, @Telefon, @Email)";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@Ad", musteri.Ad);
                    komut.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                    komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                    komut.Parameters.AddWithValue("@Email", musteri.Email);

                    SqlBaglanti.Instance.OpenConnection();

                    int sonuc = komut.ExecuteNonQuery();
                    return sonuc > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri eklenirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }

        public bool MusteriVarMi(Musteri musteri)
        {
            try
            {
                string sorgu = "SELECT COUNT(*) FROM Musteriler WHERE Telefon = @Telefon OR Email = @Email";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                    komut.Parameters.AddWithValue("@Email", musteri.Email);

                    SqlBaglanti.Instance.OpenConnection();

                    int sonuc = (int)komut.ExecuteScalar();
                    return sonuc > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri kontrol edilirken hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public bool MusteriGuncelle(Musteri musteri)
        {
            try
            {
                if (!IsValidEmail(musteri.Email))
                {
                    MessageBox.Show("Geçerli bir e-posta adresi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Öncelikle veritabanındaki mevcut verileri alıyoruz
                string kontrolSorgusu = "SELECT Ad, Soyad, Telefon, Email FROM Musteriler WHERE MusteriID = @MusteriID";
                using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgusu, baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@MusteriID", musteri.MusteriID);
                    baglanti.Open();
                    SqlDataReader reader = kontrolKomut.ExecuteReader();


                    if (reader.Read())
                    {
                        string mevcutAd = reader["Ad"].ToString();
                        string mevcutSoyad = reader["Soyad"].ToString();
                        string mevcutTelefon = reader["Telefon"].ToString();
                        string mevcutEmail = reader["Email"].ToString();


                        // Eğer veriler değişmemişse işlem yapılmaz
                        if (mevcutAd == musteri.Ad &&
                            mevcutSoyad == musteri.Soyad &&
                            mevcutTelefon == musteri.Telefon &&
                            mevcutEmail == musteri.Email)

                        {
                            MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                            return false; // Değişiklik yapılmadığı için işlem tamamlanmaz
                        }
                    }
                    reader.Close();
                }


                // Güncelleme sorgusu
                string sorgu = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, " +
                               "Telefon = @Telefon, Email = @Email  WHERE MusteriID = @MusteriID";

                SqlCommand komut = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection());

                komut.Parameters.AddWithValue("@Ad", musteri.Ad);
                komut.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                komut.Parameters.AddWithValue("@Email", musteri.Email);
                komut.Parameters.AddWithValue("@MusteriID", musteri.MusteriID);

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

        private bool DegisiklikKontrol(Musteri musteri)
        {
            try
            {
                // Veritabanındaki mevcut müşteri bilgilerini kontrol et
                if (!DegisiklikKontrol(musteri))
                {
                    MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                    return false;
                }

                // Güncelleme sorgusu
                string sorgu = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, " +
                               "Telefon = @Telefon, Email = @Email WHERE MusteriID = @MusteriID";
                using (SqlCommand komut = new SqlCommand(sorgu, SqlBaglanti.Instance.GetConnection()))
                {
                    komut.Parameters.AddWithValue("@Ad", musteri.Ad);
                    komut.Parameters.AddWithValue("@Soyad", musteri.Soyad);
                    komut.Parameters.AddWithValue("@Telefon", musteri.Telefon);
                    komut.Parameters.AddWithValue("@Email", musteri.Email);
                    komut.Parameters.AddWithValue("@MusteriID", musteri.MusteriID);

                    SqlBaglanti.Instance.OpenConnection();
                    int sonuc = komut.ExecuteNonQuery();
                    return sonuc > 0; // Güncelleme başarılı mı?
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }
        public DataTable MusterileriGetir()
        {
            try
            {
                string sorgu = "SELECT * FROM Musteriler";
                SqlDataAdapter veriler = new SqlDataAdapter(sorgu, baglanti);
                DataTable tablo = new DataTable();
                veriler.Fill(tablo);
                return tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler getirilirken hata oluştu: " + ex.Message);
                return null;
            }
        }

        public DataTable UrunleriGetir()
        {
            try
            {
                string sorgu = "SELECT UrunID, UrunAdi, BirimFiyati FROM Urunler";
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
        public int UrunIDBul(string urunAd)
        {
            string query = "SELECT UrunID FROM Urunler WHERE UrunAdi = @urunAd";
            using (SqlConnection baglanti = SqlBaglanti.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, baglanti))
            {
                cmd.Parameters.AddWithValue("@urunAd", urunAd);

                try
                {
                    baglanti.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                    return -1; // Hata durumunda -1 dönebiliriz
                }
            }
        }
        public decimal UrunFiyatiniGetir(int urunID)
        {
            try
            {
                string sorgu = "SELECT BirimFiyati FROM Urunler WHERE UrunID = @UrunID";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunID", urunID);
                    SqlBaglanti.Instance.OpenConnection();

                    object sonuc = komut.ExecuteScalar();
                    if (sonuc != null && decimal.TryParse(sonuc.ToString(), out decimal fiyat))
                    {
                        return fiyat;
                    }
                    else
                    {
                        throw new Exception("Ürün bulunamadı veya fiyat alınamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün fiyatı alınırken hata oluştu: " + ex.Message);
                return 0;
            }
            finally
            {
                SqlBaglanti.Instance.CloseConnection();
            }
        }


        public bool StokKontrolEt(int urunID, int satisMiktari)
        {

            string sorgu = "SELECT MevcutStok FROM Stoklar WHERE UrunID = @UrunID";
            using (SqlConnection baglanti = SqlBaglanti.Instance.GetConnection())
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@UrunID", urunID);

                try
                {
                    baglanti.Open();
                    object sonuc = komut.ExecuteScalar();

                    if (sonuc != null && int.TryParse(sonuc.ToString(), out int mevcutStok))
                    {
                        return mevcutStok >= satisMiktari;
                    }
                    else
                    {
                        throw new InvalidOperationException("Stok bilgisi alınamadı veya ürün bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Stok kontrolü sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool StokGuncelle(int urunID, int satisMiktari)
        {
            string sorgu = "UPDATE Stoklar SET MevcutStok = MevcutStok - @Adet WHERE UrunID = @UrunID";
            using (SqlConnection baglanti = SqlBaglanti.Instance.GetConnection())
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@Adet", satisMiktari);
                komut.Parameters.AddWithValue("@UrunID", urunID);

                try
                {
                    baglanti.Open();
                    int etkilenenSatir = komut.ExecuteNonQuery();

                    if (etkilenenSatir > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new InvalidOperationException("Stok güncellemesi başarısız oldu. Ürün bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Stok güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public decimal ToplamFiyat()
        {
            decimal toplam = 0;
            foreach (var urun in Urunler)
            {
                toplam += urun.BirimFiyat * urun.Adet;
            }
            return toplam;
        }

        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
        }

        public void UrunSil(string urunAd, int adet)
        {
            var urun = Urunler.FirstOrDefault(u => u.UrunAd == urunAd && u.Adet == adet);

            if (urun != null)
            {
                // Adet kontrolü yap ve güncelle
                if (urun.Adet >= adet)
                {
                    urun.Adet -= adet;

                    // Eğer ürünün adedi sıfıra düşerse, tamamen kaldır
                    if (urun.Adet == 0)
                    {
                        Urunler.Remove(urun);
                    }
                }
            }
        }

        public void SepetiSifirla()
        {
            Urunler.Clear();
            ToplamFiyat(); // Toplam fiyatı sıfırla
        }
        public void KaydetSatis(int musteriID, int urunID, int kullaniciID, int satisMiktari, decimal toplamFiyat)
        {
            string sorgu = @"INSERT INTO Satislar (MusteriID, UrunID, KullaniciID, SatisMiktari, ToplamFiyat, SatisTarihi) VALUES (@MusteriID, @UrunID, @KullaniciID, @Adet, @ToplamFiyat, @SatisTarihi)";
            using (SqlConnection baglanti = SqlBaglanti.Instance.GetConnection())
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@MusteriID", musteriID);
                komut.Parameters.AddWithValue("@UrunID", urunID);
                komut.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                komut.Parameters.AddWithValue("@Adet", satisMiktari);
                komut.Parameters.AddWithValue("@ToplamFiyat", toplamFiyat);
                komut.Parameters.AddWithValue("@SatisTarihi", DateTime.Now);

                try
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Satış kaydı sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


   




