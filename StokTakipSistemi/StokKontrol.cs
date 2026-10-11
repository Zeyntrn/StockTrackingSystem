using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StokTakipSistemi.KullaniciGirisIslemleri;
using Serilog;

namespace StokTakipSistemi
{
    public partial class StokKontrol : Form
    {
        private StokTakip stoktakip;
        private KullaniciGirisIslemleri kullaniciGiris;

        public StokKontrol()
        {
            InitializeComponent();
            stoktakip = new StokTakip();
            kullaniciGiris = new KullaniciGirisIslemleri();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StokKontrol_Load(object sender, EventArgs e)
        {
            UrunleriComboBoxaYukle();

            dgvStoklar.RowPrePaint += dgvStoklar_RowPrePaint;
            dgvStoklar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void UrunleriComboBoxaYukle()
        {
            cmbUrunSec.Items.Clear();
            DataTable urunler = stoktakip.UrunleriGetir();

            if (urunler != null)
            {
                foreach (DataRow row in urunler.Rows)
                {
                    int urunID = (int)row["UrunID"];
                    string urunAdi = row["UrunAdi"].ToString();

                    // Ürünleri KeyValuePair olarak ekle
                    cmbUrunSec.Items.Add(new KeyValuePair<int, string>(urunID, urunAdi));
                }

                cmbUrunSec.DisplayMember = "Value"; // ComboBox'ta UrunAdi gösterilecek
                cmbUrunSec.ValueMember = "Key";    // Seçimden sonra UrunID alınacak
            }
            else
            {
                MessageBox.Show("Ürünler yüklenirken bir hata oluştu.");
                Log.Warning("Ürünler yüklenirken hata oluştu.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUrunSec.SelectedItem == null || string.IsNullOrWhiteSpace(cmbDepoSec.Text) || string.IsNullOrWhiteSpace(txtMevcutStok.Text) || string.IsNullOrWhiteSpace(txtMinStok.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    Log.Warning("Stok ekleme işlemi başarısız oldu: Tüm alanlar doldurulmadı.");
                    return;
                }

                var secilenUrun = (KeyValuePair<int, string>)cmbUrunSec.SelectedItem;
                int urunID = secilenUrun.Key;
                string urunAdi = secilenUrun.Value;
                string depoAdi = cmbDepoSec.Text;
                int miktar = int.Parse(txtMevcutStok.Text);
                int kullaniciID = KullaniciGirisIslemleri.KullaniciOturumu.KullaniciID;
                int minimumStok = int.Parse(txtMinStok.Text);

                // Ürün nesnesi oluşturuluyor
                StokTakip.Urun yeniUrun = new StokTakip.Urun(urunID, urunAdi, depoAdi, miktar, kullaniciID, minimumStok);

                // Stok ekleme işlemi
                bool sonuc = stoktakip.StokEkle(yeniUrun);

                if (sonuc)
                {
                    txtMevcutStok.Clear();
                    cmbDepoSec.SelectedIndex = -1;
                    cmbUrunSec.SelectedIndex = -1;
                    txtMinStok.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                Log.Error(ex, "Stok ekleme işlemi sırasında beklenmeyen bir hata oluştu.");
            }
        }

        private void dgvStoklar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void StoklariYukle()
        {
            DataTable stoklar = stoktakip.StoklariGetir();

            if (stoklar != null)
            {
                dgvStoklar.DataSource = stoklar;

                // Kolon başlıklarını daha kullanıcı dostu yapmak için değiştirebilirsiniz.
                dgvStoklar.Columns["UrunAdi"].HeaderText = "Ürün Adı";
                dgvStoklar.Columns["DepoAdi"].HeaderText = "Depo Adı";
                dgvStoklar.Columns["MevcutStok"].HeaderText = "Mevcut Stok";
                dgvStoklar.Columns["MinimumStokSeviyesi"].HeaderText = "Minimum Stok Seviyesi";
                dgvStoklar.Columns["SonGuncellemeTarihi"].HeaderText = "Son Güncelleme Tarihi";
                dgvStoklar.Columns["KullaniciAdSoyad"].HeaderText = "Kullanıcı Adı Soyadı";

                // İsterseniz bazı kolonları gizleyebilirsiniz.
             //   dgvStoklar.Columns["StokID"].Visible = false;
                dgvStoklar.ClearSelection();
                dgvStoklar.CurrentCell = null;
            }
            else
            {
                MessageBox.Show("Stoklar yüklenirken hata oluştu.");
                Log.Warning("Stoklar yüklenirken hata oluştu: Stok verisi boş.");
            }
        }

        private void dgvStoklar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // DataGridView'deki mevcut satırı al
            DataGridViewRow satir = dgvStoklar.Rows[e.RowIndex];

            // Stok miktarını ve minimum stok seviyesini kontrol et
            if (satir.Cells["MevcutStok"].Value != null &&
                satir.Cells["MinimumStokSeviyesi"].Value != null &&
                int.TryParse(satir.Cells["MevcutStok"].Value.ToString(), out int mevcutStok) &&
                int.TryParse(satir.Cells["MinimumStokSeviyesi"].Value.ToString(), out int minimumStokSeviye))
            {
                // Eğer mevcut stok, minimum stok seviyesine eşit veya daha az ise
                if (mevcutStok <= minimumStokSeviye)
                {
                    satir.DefaultCellStyle.BackColor = Color.Red;
                    satir.DefaultCellStyle.ForeColor = Color.White; // Yazı rengini beyaz yap
                }
                else
                {
                    // Normal durum için renkleri sıfırla (isteğe bağlı)
                    satir.DefaultCellStyle.BackColor = Color.White;
                    satir.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dgvStoklar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStoklar.CurrentRow != null) // Geçerli bir satır seçildiğinde
            {
                DataGridViewRow row = dgvStoklar.CurrentRow;

                txtMevcutStok.Text = row.Cells["MevcutStok"].Value?.ToString();
                txtMinStok.Text = row.Cells["MinimumStokSeviyesi"].Value?.ToString();
                // cmbDepoSec.SelectedItem= dgvStoklar.Rows[1].Cells["DepoAdi"].Value.ToString();

                string UrunAdi = row.Cells["UrunAdi"].Value?.ToString();
                string depoAdi = row.Cells["DepoAdi"].Value?.ToString();

                foreach (KeyValuePair<int, string> item in cmbUrunSec.Items)
                {
                    if (item.Value == UrunAdi)
                    {
                        cmbUrunSec.SelectedItem = item;
                        break; // Eşleşen öğeyi bulduğumuzda döngüyü sonlandırıyoruz
                    }
                }
                foreach (var item in cmbDepoSec.Items)
                {
                    if (item.ToString() == depoAdi)
                    {
                        cmbDepoSec.SelectedItem = item;
                        break; // Eşleşen öğeyi bulduğumuzda döngüyü sonlandırıyoruz
                    }
                }


            }


        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            StoklariYukle();
            txtMevcutStok.Clear();
            txtMinStok.Clear();
            cmbUrunSec.SelectedIndex = -1;
            cmbDepoSec.SelectedIndex = -1;

        }
    }
}
