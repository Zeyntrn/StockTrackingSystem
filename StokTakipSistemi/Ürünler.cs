using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static StokTakipSistemi.UrunIslemleri;
using Serilog;

namespace StokTakipSistemi
{
    public partial class Ürünler : Form
    {

        private UrunIslemleri urunIslemleri;
        public Ürünler()
        {
            InitializeComponent();
            urunIslemleri = new UrunIslemleri();

        }


        private void Ürünler_Load(object sender, EventArgs e)
        {
            AltKategorileriYukle();
            // DataGridView'e veri yüklendikten sonra, herhangi bir satırın seçili olmamasını sağla
            dgvUrunler.ClearSelection();

            // İlk satırın seçili olmasını engellemek için CurrentCell'i null yapabilirsiniz
            dgvUrunler.CurrentCell = null;
        }
        private void VerileriYukle()
        {
            DataTable dt = urunIslemleri.UrunleriGetir();
            dgvUrunler.DataSource = dt;
            dgvUrunler.ClearSelection();

            // İstediğiniz sütunları düzenleyebilirsiniz
            dgvUrunler.Columns["UrunID"].Visible = false; // UrunID'yi gizler
        }

        private void AltKategorileriYukle()
        {
            cmbAltKategori.Items.Clear();
            DataTable dt = urunIslemleri.AltKategoriler();

            foreach (DataRow row in dt.Rows)
            {
                int altKategoriID = (int)row["AltKategoriID"];
                string altKategoriAdi = row["AltKategoriAdi"].ToString();

                // AltKategoriID ve AltKategoriAdi'ni KeyValuePair olarak ekle
                cmbAltKategori.Items.Add(new KeyValuePair<int, string>(altKategoriID, altKategoriAdi));
            }

            cmbAltKategori.DisplayMember = "Value"; // ComboBox'ta AltKategoriAdi gösterilecek
            cmbAltKategori.ValueMember = "Key";    // Seçimden sonra AltKategoriID alınacak


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Alt kategori doğrulaması
                if (cmbAltKategori.SelectedItem is not KeyValuePair<int, string> selectedAltKategori)
                {
                    MessageBox.Show("Lütfen bir alt kategori seçiniz.");
                    Log.Warning("Ürün ekleme işlemi başarısız oldu. Alt kategori seçilmedi.");
                    return;
                }

                // Urun nesnesini oluştur
                Urun yeniUrun = new Urun
                {
                    UrunAd = txtUrunAd.Text,
                    AltKategoriID = selectedAltKategori.Key,
                    BirimFiyat = decimal.Parse(txtBirimFiyat.Text),
                    AlisFiyat = decimal.Parse(txtAlısFiyat.Text),
                    FotoAdres = txtFotoAdres.Text
                };

                // Urun ekleme işlemini gerçekleştir
                UrunIslemleri urunIslemleri = new UrunIslemleri();
                bool eklemeSonucu = urunIslemleri.UrunEkle(yeniUrun);

                // Sonuç mesajını göster
                if (eklemeSonucu)
                {
                    MessageBox.Show("Ürün başarıyla eklendi!");
                    Log.Information("Ürün başarıyla eklendi. Ürün Adı: {UrunAd}", yeniUrun.UrunAd);
                }
                else
                {
                    MessageBox.Show("Ürün eklenirken hata oluştu.");
                    Log.Warning("Ürün ekleme işlemi sırasında hata oluştu. Ürün Adı: {UrunAd}", yeniUrun.UrunAd);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir sayı formatında fiyat bilgisi giriniz.");
                Log.Error("Ürün ekleme işlemi sırasında format hatası oluştu. Kullanıcı geçersiz fiyat bilgisi girdi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
                Log.Error(ex, "Ürün ekleme işlemi sırasında beklenmeyen bir hata oluştu.");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            VerileriYukle();
            txtUrunAd.Clear();
            txtBirimFiyat.Clear();
            txtAlısFiyat.Clear();
            txtFotoAdres.Clear();
            cmbAltKategori.SelectedIndex = -1; // ComboBox seçimini sıfırla

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtUrunAd.Clear();
            txtBirimFiyat.Clear();
            txtAlısFiyat.Clear();
            txtFotoAdres.Clear();
            cmbAltKategori.SelectedIndex = -1; // ComboBox seçimini sıfırla
        }

        private void button2_Click(object sender, EventArgs e)
        {




            // DataGridView'de bir satır seçilip seçilmediğini kontrol edin
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                // Seçili satırın UrunID'sini alın
                int UrunId = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["UrunID"].Value);
                UrunIslemleri urunIslemleri = new UrunIslemleri();
                // UrunSil metodunu çağırarak silme işlemini yapın
                bool sonuc = urunIslemleri.UrunSil(UrunId);
                VerileriYukle();

            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUrunler.SelectedRows.Count > 0)
            {
                dgvUrunler.ClearSelection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili bir satır var mı kontrol ediyoruz
            if (dgvUrunler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                Log.Warning("Ürün güncelleme işlemi başarısız oldu: Seçili bir satır yok.");
                return;
            }

            // Seçili satırdan verileri alıyoruz
            DataGridViewRow row = dgvUrunler.CurrentRow;

            if (cmbAltKategori.SelectedItem is KeyValuePair<int, string> selectedAltKategori)
            {
                try
                {
                    // Kullanıcıdan alınan verileri bir Urun nesnesine atıyoruz
                    Urun urun = new Urun
                    {
                        UrunID = Convert.ToInt32(row.Cells["UrunID"].Value),
                        UrunAd = txtUrunAd.Text.Trim(),
                        AltKategoriID = selectedAltKategori.Key,
                        BirimFiyat = decimal.Parse(txtBirimFiyat.Text),
                        AlisFiyat = decimal.Parse(txtAlısFiyat.Text),
                        FotoAdres = txtFotoAdres.Text.Trim()
                    };

                    // Güncelleme işlemi
                    UrunIslemleri urunIslemleri = new UrunIslemleri();
                    bool sonuc = urunIslemleri.UrunGuncelle(urun);

                    if (sonuc)
                    {
                        Log.Information("Ürün başarıyla güncellendi. Ürün Adı: {UrunAd}", urun.UrunAd);
                        MessageBox.Show("Ürün başarıyla güncellendi!");
                        // DataGridView'i yenilemek için bir metot çağırabilirsiniz
                        VerileriYukle();
                    }
                    else
                    {
                        MessageBox.Show("Ürün güncelleme işlemi yapılmadı. Belki değişiklik yapmamış olabilirsiniz.");
                        Log.Warning("Ürün güncelleme işlemi sırasında değişiklik yapılmamış olabilir. Ürün Adı: {UrunAd}", urun.UrunAd);

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lütfen geçerli değerler giriniz.");
                    Log.Warning("Alt kategori seçilmeden ürün güncellenmeye çalışıldı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    Log.Error("Ürün güncelleme işlemi sırasında format hatası oluştu. Kullanıcı geçersiz değerler girdi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir alt kategori seçiniz.");
                Log.Error("Ürün güncelleme işlemi sırasında beklenmeyen bir hata oluştu.");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvUrunler.CurrentRow != null) // Geçerli bir satır seçildiğinde
            {
                DataGridViewRow row = dgvUrunler.CurrentRow; // currentrow seçili olan satırı temsir eder

                txtUrunAd.Text = row.Cells["UrunAdi"].Value?.ToString();
                //  cmbAltKategori.SelectedValue = row.Cells["AltKategoriAdi"].Value ;
                txtBirimFiyat.Text = row.Cells["BirimFiyati"].Value?.ToString();
                txtAlısFiyat.Text = row.Cells["AlisFiyati"].Value?.ToString();
                txtFotoAdres.Text = row.Cells["FotoYolu"].Value?.ToString();

                // Seçili alt kategori adını alıyoruz
                string altKategoriAdi = row.Cells["AltKategoriAdi"].Value?.ToString();

                // ComboBox'ta AltKategoriAdi'ni bulup seçiyoruz
                foreach (KeyValuePair<int, string> item in cmbAltKategori.Items)
                {
                    if (item.Value == altKategoriAdi)
                    {
                        cmbAltKategori.SelectedItem = item;
                        break; // Eşleşen öğeyi bulduğumuzda döngüyü sonlandırıyoruz
                    }
                }


            }




        }

        private void txtBirimFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnızca rakam (0-9), Backspace ve nokta/virgül girişine izin ver
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // Geçersiz karakter girişini iptal et
            }
        }

        private void txtAlısFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnızca rakam (0-9), Backspace ve nokta/virgül girişine izin ver
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // Geçersiz karakter girişini iptal et
            }
        }
    }
}




