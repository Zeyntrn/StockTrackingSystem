using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static StokTakipSistemi.KullaniciYönetim;
using static StokTakipSistemi.MusteriIslemleri;

namespace StokTakipSistemi
{
    public class Fatura
    {
        private SqlConnection baglanti;
        public Fatura()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
        }

       
        public DataTable FaturalıGetir()
        {
            try
            {
                string sorgu = @"
            SELECT 
            Satislar.SatisID,
            Urunler.UrunAdi,
             Musteriler.Ad + ' ' + Musteriler.Soyad AS MusteriAdSoyad,
             Kullanicilar.Ad + ' ' + Kullanicilar.Soyad AS KullaniciAdSoyad,
            Satislar.SatisTarihi,
            Satislar.ToplamFiyat
                FROM 
                    Satislar
                JOIN 
                    Urunler ON Satislar.UrunID = Urunler.UrunID
                JOIN 
                    Musteriler ON Satislar.MusteriID = Musteriler.MusteriID
                JOIN 
            Kullanicilar ON Satislar.KullaniciID = Kullanicilar.KullaniciID
        ";
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

        
    }
}

