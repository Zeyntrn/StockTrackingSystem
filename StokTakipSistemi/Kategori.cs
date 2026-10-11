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
    public partial class Kategori : Form
    {
        private KategoriIslemleri urunIslemleri;
        public Kategori()
        {
            InitializeComponent();
            urunIslemleri = new KategoriIslemleri();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgvUrunleriGoster.Rows[e.RowIndex].Cells["UrunID"] != null)
            {
                // Seçilen ürünün ID'sini alıyoruz
                int urunID = Convert.ToInt32(dgvUrunleriGoster.Rows[e.RowIndex].Cells["UrunID"].Value);

                // Veritabanından ilgili ürünün resim yolunu al
                string FotoYolu = urunIslemleri.GetUrunResmi(urunID);

                // Eğer foto yolu varsa, PictureBox'a yükle
                if (!string.IsNullOrEmpty(FotoYolu))
                {
                    string tamResimYolu = FotoYolu;

                    if (System.IO.File.Exists(tamResimYolu))
                    {
                        pbFotograf.Image = Image.FromFile(tamResimYolu);
                    }

                    else
                    {
                        // Resim bulunamazsa boş bir şey gösterebiliriz
                        pbFotograf.Image = null;
                        Log.Warning("Ürün için resim yolu bulunamadı. ÜrünID: {UrunID}", urunID);
                        MessageBox.Show($"Ürün resmi bulunamadı: {tamResimYolu}");
                    }
                }
                else
                {
                    pbFotograf.Image = null;
                    Log.Error("Ürün resmi yüklenirken bir hata oluştu.");
                    MessageBox.Show("Ürün için resim yolu bulunamadı.");
                }

            }

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void üSTKATEGORİToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Kategori_Load(object sender, EventArgs e)
        {
            UrunleriYukle();
            KategorileriYukle();
            dgvUrunleriGoster.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void UrunleriYukle()
        {
            try
            {
                dgvUrunleriGoster.DataSource = urunIslemleri.UrunleriGetir();
                dgvUrunleriGoster.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void KategorileriYukle()
        {
            ToolStripMenuItem[] anaKategoriler =
            {
                DISGIYIMKATEGORIToolStripMenuItem,
                ALTGIYIMToolStripMenuItem,
                USTKATEGORIToolStripMenuItem,
                AKSESUARToolStripMenuItem
            };

            foreach (var anaMenu in anaKategoriler)
            {
                foreach (ToolStripMenuItem altMenu in anaMenu.DropDownItems)
                {
                    // Alt kategori ID'lerini ekleme
                    if (altMenu.Text == "Trençkot") altMenu.Tag = 1;
                    else if (altMenu.Text == "Kaban") altMenu.Tag = 2;
                    else if (altMenu.Text == "Mont") altMenu.Tag = 4;
                    else if (altMenu.Text == "Ceket/Blazer") altMenu.Tag = 5;
                    else if (altMenu.Text == "Sweat") altMenu.Tag = 7;
                    else if (altMenu.Text == "Tshirt") altMenu.Tag = 8;
                    else if (altMenu.Text == "Gömlek") altMenu.Tag = 6;
                    else if (altMenu.Text == "Etek") altMenu.Tag = 10;
                    else if (altMenu.Text == "Pantolon") altMenu.Tag = 9;
                    else if (altMenu.Text == "Eşorfman Altı") altMenu.Tag = 12;
                    else if (altMenu.Text == "Şort") altMenu.Tag = 11;
                    else if (altMenu.Text == "Çanta") altMenu.Tag = 13;
                    else if (altMenu.Text == "Çorap") altMenu.Tag = 14;
                    else if (altMenu.Text == "Atkı") altMenu.Tag = 15;
                    else if (altMenu.Text == "Şapka") altMenu.Tag = 16;

                    // Click olayını bağlama
                    altMenu.Click += AltKategoriSecildi;
                }
            }
        }
        private void AltKategoriSecildi(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem secilenMenu && secilenMenu.Tag is int kategoriID)
            {
                try
                {
                    dgvUrunleriGoster.DataSource = urunIslemleri.UrunleriKategoriyeGoreGetir(kategoriID);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Alt kategori seçimi sırasında bir hata oluştu. KategoriID: {KategoriID}", kategoriID);
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DISGIYIMKATEGORIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arananUrunAdi = txtArama.Text.Trim(); // TextBox'tan ürün adını al
            if (string.IsNullOrEmpty(arananUrunAdi))
            {
                MessageBox.Show("Lütfen bir ürün adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Warning("Arama yapılmaya çalışıldı ancak ürün adı girilmedi.");
                return;
            }

            try
            {


                string fotoYolu = urunIslemleri.UrunFoto(arananUrunAdi);

                if (!string.IsNullOrEmpty(fotoYolu) && File.Exists(fotoYolu))
                {
                    pbFotograf.Image = Image.FromFile(fotoYolu);
                }
                else
                {
                    pbFotograf.Image = null;
                    MessageBox.Show("Girilen ada sahip ürün resmi bulunamadı.");
                    Log.Warning("Ürün resmi bulunamadı. Ürün adı: {UrunAdi}, Resim yolu: {FotoYolu}", arananUrunAdi, fotoYolu ?? "Boş");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ürün arama işlemi sırasında bir hata oluştu. Aranan ürün adı: {UrunAdi}", arananUrunAdi);
                MessageBox.Show("Hata: " + ex.Message);
            }


        }
    }
}
