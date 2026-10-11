using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StokTakipSistemi.MusteriIslemleri;
using Serilog;
using Serilog.Core;
using System.Text.RegularExpressions;

namespace StokTakipSistemi
{
    public partial class Satışİşlemleri : Form
    {
        private MusteriIslemleri musteriIslemler;

        public Satışİşlemleri()
        {
            InitializeComponent();
            musteriIslemler = new MusteriIslemleri();


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void btnMusteriKayit_Click(object sender, EventArgs e)
        {
            try
            {


                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtMusteriAd.Text) ||
                    string.IsNullOrWhiteSpace(txtMusteriSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(mskNumara.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Müşteri kayıt işlemi başarısız: Tüm alanlar doldurulmadı.");
                    return;
                }

                // Yeni müşteri oluştur
                Musteri yeniMusteri = new Musteri
                {
                    Ad = txtMusteriAd.Text.Trim(),
                    Soyad = txtMusteriSoyad.Text.Trim(),
                    Telefon = mskNumara.Text.Trim(),
                    Email = txtMail.Text.Trim()
                };

                MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
                bool eklemeSonucu = musteriIslemleri.MusteriEkle(yeniMusteri);

                if (eklemeSonucu)
                {
                    MessageBox.Show("Müşteri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Müşteri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Musteriler(); // Verileri yenile
                    Temizle(); // Formu temizle
                }
                else
                {
                    MessageBox.Show("Müşteri eklenirken bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Müşteri eklenirken bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'de seçilen satırı kontrol et
                if (dgvMusteriler.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz müşteriyi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Müşteri güncelleme işlemi başarısız: Seçilen müşteri yok.");
                    return;
                }

                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtMusteriAd.Text) ||
                    string.IsNullOrWhiteSpace(txtMusteriSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(mskNumara.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Müşteri güncelleme işlemi başarısız: Tüm alanlar doldurulmadı.");
                    return;
                }

                // Güncelleme için müşteri nesnesi oluştur
                Musteri musteriGuncelle = new Musteri
                {
                    MusteriID = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells["MusteriID"].Value),
                    Ad = txtMusteriAd.Text,
                    Soyad = txtMusteriSoyad.Text,
                    Telefon = mskNumara.Text,
                    Email = txtMail.Text
                };

                // Müşteri işlemleri
                MusteriIslemleri musteriIslemleri = new MusteriIslemleri();
                bool guncelleSonucu = musteriIslemleri.MusteriGuncelle(musteriGuncelle);

                if (guncelleSonucu)
                {
                    MessageBox.Show("Müşteri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Information("Müşteri başarıyla güncellendi: ID: {MusteriID}, Ad: {MusteriAd} {MusteriSoyad}",
               musteriGuncelle.MusteriID, musteriGuncelle.Ad, musteriGuncelle.Soyad);
                    Musteriler(); // Güncel müşteri listesini yükle
                    Temizle(); // Formu temizle
                }
                else
                {
                    MessageBox.Show("Müşteri güncellenirken bir hata oluştu veya değişiklik yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Müşteri güncellenirken sorun oluştu veya değişiklik yapılmadı: ID: {MusteriID}", musteriGuncelle.MusteriID);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Müşteri güncelleme sırasında beklenmeyen bir hata oluştu.");
            }
        }

        private void Urunler()
        {
            dgvUrunler.DataSource = musteriIslemler.UrunleriGetir();
        }

        private void Musteriler()
        {
            dgvMusteriler.DataSource = musteriIslemler.MusterileriGetir();

        }

        private void btnMusteriGetir_Click(object sender, EventArgs e)
        {
            Musteriler();
            Temizle();
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.CurrentRow != null) // Geçerli bir satır seçildiğinde
            {
                DataGridViewRow row = dgvMusteriler.CurrentRow; // currentrow seçili olan satırı temsir eder

                txtMusteriAd.Text = row.Cells["Ad"].Value?.ToString();
                txtMusteriSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                //  cmbKullaniciTuru.Text = row.Cells["KullaniciTuru"].Value?.ToString();
                mskNumara.Text = row.Cells["Telefon"].Value?.ToString();
                txtMail.Text = row.Cells["Email"].Value?.ToString();

            }
        }

        private void Temizle()
        {
            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtMail.Clear();
            mskNumara.Clear();
        }



        private void Satışİşlemleri_Load(object sender, EventArgs e)
        {



        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            try
            {
                // Müşteri seçimini kontrol et
                if (dgvMusteriler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Satış işlemi başarısız: Müşteri seçilmedi.");
                    return;
                }

                int musteriID = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);
                int kullaniciID = KullaniciGirisIslemleri.KullaniciOturumu.KullaniciID;

                // Sepet kontrolü
                if (listBoxSepet.Items.Count == 0)
                {
                    MessageBox.Show("Sepette ürün bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Log.Warning("Satış işlemi başarısız: Sepette ürün yok.");
                    return;
                }

                // Satış işlemleri
                foreach (string item in listBoxSepet.Items)
                {
                    try
                    {
                        // ListBox verisini ayrıştır
                        string[] bilgiler = item.Split('-');
                        if (bilgiler.Length < 3)
                        {
                            MessageBox.Show($"Geçersiz veri formatı: {item}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Geçersiz veri formatı: {SepetItem}", item);
                            continue;
                        }

                        string urunAd = bilgiler[0].Trim(); // Ürün adı
                        string adetMetni = bilgiler[1].Trim(); // Adet
                        string toplamFiyatMetni = bilgiler[2].Trim(); // Toplam fiyat

                        if (!int.TryParse(adetMetni.Replace("Adet", "").Trim(), out int satisMiktari) || satisMiktari <= 0)
                        {
                            MessageBox.Show($"Geçersiz adet formatı: {adetMetni}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Geçersiz adet formatı: {AdetMetni}", adetMetni);
                            continue;
                        }

                        toplamFiyatMetni = toplamFiyatMetni.Replace("₺", "").Replace("Toplam:", "").Trim();
                        if (!decimal.TryParse(toplamFiyatMetni, out decimal toplamFiyat) || toplamFiyat <= 0)
                        {
                            MessageBox.Show($"Geçersiz toplam fiyat formatı: {toplamFiyatMetni}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Geçersiz toplam fiyat formatı: {ToplamFiyatMetni}", toplamFiyatMetni);

                            continue;
                        }

                        // Ürün ID'yi bul
                        int urunID = musteriIslemler.UrunIDBul(urunAd);
                        if (urunID == -1)
                        {
                            MessageBox.Show($"Ürün bulunamadı: {urunAd}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Ürün bulunamadı: {UrunAd}", urunAd);
                            continue;
                        }

                        // Stok kontrolü
                        if (!musteriIslemler.StokKontrolEt(urunID, satisMiktari))
                        {
                            MessageBox.Show($"Ürün: {urunAd} için yeterli stok yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Yeterli stok yok: Ürün: {UrunAd}, Adet: {SatisMiktari}", urunAd, satisMiktari);
                            continue;
                        }

                        // Satış işlemini kaydet
                        musteriIslemler.KaydetSatis(musteriID, urunID, kullaniciID, satisMiktari, toplamFiyat);

                        // Stok güncelleme
                        if (!musteriIslemler.StokGuncelle(urunID, satisMiktari))
                        {
                            MessageBox.Show($"Ürün: {urunAd} stok güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Log.Warning("Stok güncellenemedi: ÜrünID: {UrunID}, Adet: {SatisMiktari}", urunID, satisMiktari);

                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ürün satışında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error(ex, "Satış işlemi sırasında beklenmeyen bir hata oluştu.");
                        continue;
                    }
                }

                // Satış tamamlandı mesajı
                MessageBox.Show("Satış işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Information("Satış işlemi başarıyla tamamlandı.");

                // Sepeti temizle
                listBoxSepet.Items.Clear();
                Temizle();
                txtUrunAd.Clear();
                txtToplamFiyat.Text = "0";
                txtBirimFiyat.Clear();
                numericUpDown1.Value = 0;
                musteriIslemler.SepetiSifirla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Satış işlemi sırasında beklenmeyen bir hata oluştu.");
            }
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Ürün adı kontrolü
                string urunAd = txtUrunAd.Text.Trim();
                if (string.IsNullOrEmpty(urunAd))
                {
                    MessageBox.Show("Lütfen ürün adını giriniz.");
                    Log.Warning("Ürün adı boş.");
                    return;
                }

                // Ürün fiyatı kontrolü
                if (!decimal.TryParse(txtBirimFiyat.Text, out decimal urunFiyati) || urunFiyati <= 0)
                {
                    MessageBox.Show("Geçerli bir ürün fiyatı giriniz.");
                    Log.Warning("Geçersiz ürün fiyatı.");
                    return;
                }

                // Adet kontrolü
                int adet = (int)numericUpDown1.Value;
                if (adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir adet seçiniz.");
                    Log.Warning("Geçersiz adet değeri.");
                    return;
                }

                // Yeni bir ürün nesnesi oluştur

                Urun yeniUrun = new Urun(urunAd, urunFiyati, adet);

                // Sepete ürünü ekle
                musteriIslemler.UrunEkle(yeniUrun);

                // ListBox'a ürün adı, adet ve toplam fiyatı ekle
                string listeElemani = $"{urunAd} - {adet} Adet - Toplam: {yeniUrun.BirimFiyat * yeniUrun.Adet:C}";
                listBoxSepet.Items.Add(listeElemani);

                // Toplam fiyatı hesapla ve TextBox'a yaz
                txtToplamFiyat.Text = musteriIslemler.ToplamFiyat().ToString("C");

                // Bilgilendirme
                MessageBox.Show("Ürün başarıyla sepete eklendi.");
                Log.Information("Ürün Başarıyla sepete eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                Log.Error(ex, "Satış işlemi sırasında beklenmeyen bir hata oluştu.");
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dgvUrunler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUrunler.CurrentRow != null) // Geçerli bir satır seçildiğinde
            {
                DataGridViewRow row = dgvUrunler.CurrentRow; // currentrow seçili olan satırı temsir eder

                txtUrunAd.Text = row.Cells["UrunAdi"].Value?.ToString();
                txtBirimFiyat.Text = row.Cells["birimFiyati"].Value?.ToString();

            }

        }

        private void btnUrunleriGetir_Click(object sender, EventArgs e)
        {
            Urunler();

            txtBirimFiyat.Clear();
            txtUrunAd.Clear();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili bir öğe var mı kontrol et
                if (listBoxSepet.SelectedIndex != -1)
                {
                    // Seçili öğeyi al
                    string secilenUrun = listBoxSepet.SelectedItem.ToString();

                    // Ürün bilgilerini ayıkla
                    string[] urunBilgileri = secilenUrun.Split('-');
                    if (urunBilgileri.Length < 3)
                    {
                        MessageBox.Show("Ürün bilgisi okunamadı.");
                        return;
                    }

                    // Ürün adı ve adet bilgilerini ayıkla
                    string urunAd = urunBilgileri[0].Trim();
                    string adetBilgisi = urunBilgileri[1].Trim().Split(' ')[0];
                    if (!int.TryParse(adetBilgisi, out int adet))
                    {
                        MessageBox.Show("Ürün bilgisi okunamadı.");

                        return;
                    }

                    // Ürünü musteriIslemler'den kaldır
                    musteriIslemler.UrunSil(urunAd, adet);

                    // ListBox'tan ürünü kaldır
                    listBoxSepet.Items.RemoveAt(listBoxSepet.SelectedIndex);
                    // Toplam fiyatı güncelle ve TextBox'a yaz
                    decimal toplamFiyat = musteriIslemler.ToplamFiyat();
                    txtToplamFiyat.Text = toplamFiyat.ToString("C");
                    
                  

                    MessageBox.Show("Seçili ürün sepetten kaldırıldı.");
                    Log.Information("Ürün sepetten kaldırıldı.");
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir ürün seçiniz.");
                    Log.Warning("Silmek istenilen ürün seçilmedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                Log.Error(ex, "Satış işlemi sırasında beklenmeyen bir hata oluştu.");
            }
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            FaturaGortuntule ftr = new FaturaGortuntule();
            ftr.ShowDialog();
        }
    }
}
