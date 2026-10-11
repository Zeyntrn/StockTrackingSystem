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
using Serilog;


namespace StokTakipSistemi
{
    public partial class Kullanıcılar : Form
    {

        private KullaniciYönetim kullaniciYönetim;
        public Kullanıcılar()
        {
            InitializeComponent();
            kullaniciYönetim = new KullaniciYönetim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                    string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text) ||
                    cmbKullaniciTuru.SelectedItem == null)
                {
                    Log.Warning("Kullanıcı ekleme işlemi eksik bilgi nedeniyle başarısız oldu. Eksik alanlar doldurulmamış.");
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KullaniciYönetim.Kullanici yenikullanici = new KullaniciYönetim.Kullanici
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    KullaniciTuru = cmbKullaniciTuru.SelectedItem.ToString(),
                    KullaniciAd = txtKullaniciAdi.Text,
                    Email = txtMail.Text,
                    Sifre = txtSifre.Text,

                };
                KullaniciYönetim kullaniciYönetim = new KullaniciYönetim();
                bool eklemesonucu = kullaniciYönetim.KullaniciEkle(yenikullanici);
                if (eklemesonucu)
                {
                    Log.Information("Yeni kullanıcı başarıyla eklendi: {Ad} {Soyad}, Kullanıcı Türü: {KullaniciTuru}, Kullanıcı Adı: {KullaniciAd}");
                    MessageBox.Show("Kullanıcı başarıyla eklendi!");
                }
                else
                {
                    Log.Warning("Kullanıcı ekleme işlemi başarısız oldu: {Ad} {Soyad}, Kullanıcı Türü: {KullaniciTuru}, Kullanıcı Adı: {KullaniciAd}",
                yenikullanici.Ad, yenikullanici.Soyad, yenikullanici.KullaniciTuru, yenikullanici.KullaniciAd);
                    MessageBox.Show("Kullanıcı eklenirken hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı ekleme sırasında bir hata oluştu: {Ad} {Soyad}, Kullanıcı Türü: {KullaniciTuru}, Kullanıcı Adı: {KullaniciAd}, E-posta: {Email}",
            txtAd.Text, txtSoyad.Text, cmbKullaniciTuru?.SelectedItem?.ToString(), txtKullaniciAdi.Text, txtMail.Text);
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }


        }
        private void VeriYukle()
        {
            dataGridView1.DataSource = kullaniciYönetim.KullaniciGetir();
            dataGridView1.Columns["Sifre"].Visible = false;
            dataGridView1.Columns["KullaniciID"].Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // DataGridView'de bir satır seçilip seçilmediğini kontrol edin
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kullaniciID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KullaniciID"].Value);
                KullaniciYönetim kullaniciYönetim = new KullaniciYönetim();

                Log.Information("Kullanıcı silme işlemi başlatıldı. KullanıcıID: {KullaniciID}", kullaniciID);
                bool sonuc = kullaniciYönetim.KullaniciSil(kullaniciID);
                VeriYukle();
            }
            else
            {
                Log.Warning("Kullanıcı silme işlemi için hiçbir kayıt seçilmedi.");
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.");
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            VeriYukle();
            txtAd.Clear();
            txtSoyad.Clear();
            txtSifre.Clear();
            txtMail.Clear();
            txtKullaniciAdi.Clear();
            cmbKullaniciTuru.SelectedIndex = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            try
            {
                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                    string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtMail.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text) ||
                    cmbKullaniciTuru.SelectedItem == null)
                {
                    Log.Warning("Kullanıcı güncelleme işlemi başarısız oldu. Eksik bilgi girildi.");
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcı bilgilerini al
                KullaniciYönetim.Kullanici kullanici = new KullaniciYönetim.Kullanici
                {
                    KullaniciID = Convert.ToInt32(row.Cells["KullaniciID"].Value), // Kullanıcı ID
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    KullaniciTuru = cmbKullaniciTuru.SelectedItem.ToString(),
                    KullaniciAd = txtKullaniciAdi.Text,
                    Email = txtMail.Text,
                    Sifre = txtSifre.Text
                };

                // Kullanıcı yönetim sınıfını kullanarak güncelleme
                KullaniciYönetim kullaniciYonetim = new KullaniciYönetim();
                bool guncelleSonucu = kullaniciYonetim.KullaniciGuncelle(kullanici);

                if (guncelleSonucu)
                {
                    Log.Information("Kullanıcı başarıyla güncellendi. KullanıcıID: {KullaniciID}", kullanici.KullaniciID);
                    MessageBox.Show("Kullanıcı başarıyla güncellendi!");
                    // DataGridView'i güncelle
                    VeriYukle();
                }
                else
                {
                    Log.Warning("Kullanıcı güncelleme işlemi başarısız oldu veya değişiklik yapılmadı. KullanıcıID: {KullaniciID}", kullanici.KullaniciID);
                    MessageBox.Show("Kullanıcı güncellenirken bir hata oluştu veya değişiklik yapılmadı.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı güncelleme işlemi sırasında bir hata oluştu.");
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }







        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null) // Geçerli bir satır seçildiğinde
            {
                DataGridViewRow row = dataGridView1.CurrentRow; // currentrow seçili olan satırı temsir eder

                txtAd.Text = row.Cells["Ad"].Value?.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                cmbKullaniciTuru.Text = row.Cells["KullaniciTuru"].Value?.ToString();
                txtKullaniciAdi.Text = row.Cells["KullaniciAdi"].Value?.ToString();
                txtMail.Text = row.Cells["Email"].Value?.ToString();
                txtSifre.Text = row.Cells["Sifre"].Value?.ToString();
                // KayıtTarihi atlandı
                // ? kullanmamızın sebebi : bir hücrede değer yoksa hata almayı önler
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Arama metnini al
            string arama = txtArama.Text.Trim(); // Trim() boşlukları kaldırır.

            // KullaniciYönetim sınıfını kullanarak arama yap
            KullaniciYönetim kullaniciYonetim = new KullaniciYönetim();
            DataTable sonuc = kullaniciYonetim.KullaniciAra(arama);

            // Sonuçları kontrol et ve DataGridView'e bağla
            if (sonuc != null && sonuc.Rows.Count > 0)
            {
                dataGridView1.DataSource = sonuc; // Sonuçları DataGridView'e bağla
            }
            else
            {
                MessageBox.Show("Arama sonucu bulunamadı.");
                dataGridView1.DataSource = null; // DataGridView'i temizle
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciAdi.Clear();
            txtMail.Clear();
            txtSifre.Clear();
            cmbKullaniciTuru.SelectedIndex = -1;  // ComboBox'taki seçimi sıfırla
        }

    }
}





