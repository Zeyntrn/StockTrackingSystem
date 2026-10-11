using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using static StokTakipSistemi.RaporIslemleri;

namespace StokTakipSistemi
{
    public partial class Raporlar : Form
    {
        private RaporIslemleri rapor;
        public Raporlar()
        {
            InitializeComponent();
            rapor = new RaporIslemleri();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            Faturalar();
        }

        private void Faturalar()
        {
            DataTable satislarTable = rapor.GetTumSatislar();

            if (satislarTable.Rows.Count > 0)
            {
                dgvRapor.DataSource = satislarTable; // DataGridView'e bağla
            }
            else
            {
                MessageBox.Show("Hiç satış bilgisi bulunamadı.");
                Log.Warning("Satış bilgisi bulunamadı");
            }
        }

        private void btnSatisprsnl_Click(object sender, EventArgs e)
        {
            Personel personel = rapor.GetEnCokSatanPersonel();

            if (personel != null)
            {
                txtsatisyapanersonel.Text = personel.AdSoyad;
                MessageBox.Show($"En çok satış yapan personel: {personel.AdSoyad}\n" +
                                $"Satış Sayısı: {personel.SatisSayisi}\n" +
                                $"Toplam Tutar: {personel.ToplamTutar:C}");
            }
            else
            {
                MessageBox.Show("Personel bilgisi bulunamadı.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faturalar();
        }

        private void btnSatisGetir_Click(object sender, EventArgs e)
        {
            DateTime secilenTarih = datetimeZaman.Value; // DateTimePicker'dan seçilen tarihi al
            DataTable satislarTable = rapor.GetSatislarByTarih(secilenTarih);

            if (satislarTable.Rows.Count > 0)
            {
                dgvRapor.DataSource = satislarTable; // Satışları DataGridView'e bağla
            }
            else
            {
                MessageBox.Show("Seçilen tarihte satış bulunamadı.");
                Log.Warning($"Seçilen tarihte ({secilenTarih.ToShortDateString()}) satış bulunamadı.");
                dgvRapor.DataSource = null; // Veri yoksa tabloyu temizle
            }
        }
    }
}
