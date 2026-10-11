using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{

    public class KategoriIslemleri
    {

        private SqlConnection baglanti;
        public KategoriIslemleri()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }
        public DataTable UrunleriGetir()
        {
            try
            {
                
                string sorgu = "SELECT UrunID, UrunAdi FROM Urunler";
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, baglanti);
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                return tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Ürünleri getirirken hata oluştu: " + ex.Message);
            }
            finally
            {
                
            }
        }
        public DataTable UrunleriKategoriyeGoreGetir(string kategoriAdi)
        {
            try
            {
              
                string sorgu = @"SELECT UrunID, UrunAdi 
                                 FROM Urunler 
                                 WHERE AltKategoriID IN (
                                     SELECT AltKategoriID 
                                     FROM AltKategoriler 
                                     WHERE AltKategoriAdi = @AltKategoriAdi)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@AltKategoriAdi", kategoriAdi);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                return tablo;
            }
            catch (Exception ex)
            {
                throw new Exception("Kategoriye göre ürünleri getirirken hata oluştu: " + ex.Message);
            }
           
        } 

        public void KategoriSecimiYap(object sender, EventArgs e)
        {
            //KategoriSecimiYap metodu, bir menü öğesine (kategori) tıklama işlemini yakalar
            //ve tıklanan menünün metnine (Text özelliği) göre ürünleri filtrelemek için UrunleriKategoriyeGoreGetir metodunu çağırır.
            ToolStripMenuItem secilenMenu = sender as ToolStripMenuItem;
            if (secilenMenu != null)
            {
                string kategoriAdi = secilenMenu.Text; // Tıklanan kategori adı
                UrunleriKategoriyeGoreGetir(kategoriAdi);
            }

        }
        public string GetUrunResmi(int urunID)
        {
            string sorgu = "SELECT FotoYolu FROM Urunler WHERE UrunID = @UrunID";
            try
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunID", urunID);

                    baglanti.Open();
                    object sonuc = komut.ExecuteScalar();
                    return sonuc != null && sonuc != DBNull.Value ? sonuc.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün resmini alırken hata oluştu.", ex);
            }
            finally
            {
                baglanti.Close();
            }


        }
        public string UrunFoto(string UrunAdi)
        {
            string sorgu = "SELECT FotoYolu FROM Urunler WHERE UrunAdi = @UrunAdi";
            try
            {
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@UrunAdi", UrunAdi);

                    baglanti.Open();
                    object sonuc = komut.ExecuteScalar();
                    return sonuc != null && sonuc != DBNull.Value ? sonuc.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ürün adına göre resim alırken hata oluştu.", ex);
            }
            finally
            {
                baglanti.Close();
            }
        


    }
        public DataTable UrunleriKategoriyeGoreGetir(int kategoriID)
        {
            try
            {
              
                string sorgu = @"SELECT UrunID, UrunAdi 
                         FROM Urunler 
                         WHERE AltKategoriID IN (
                             SELECT AltKategoriID 
                             FROM AltKategoriler 
                             WHERE AltKategoriID = @AltKategoriID)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@AltKategoriID", kategoriID);

                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable tablo = new DataTable();
                adapter.Fill(tablo);
                return tablo;
            }
            catch (Exception ex)
            {
                throw new Exception("Kategoriye göre ürünleri getirirken hata oluştu: " + ex.Message);
            }
           
        }
    }

}

