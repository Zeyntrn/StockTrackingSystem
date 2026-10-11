using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace StokTakipSistemi
{
    public partial class Loglar : Form
    {
        private SqlConnection baglanti;
        public Loglar()
        {
            baglanti = SqlBaglanti.Instance.GetConnection();
            InitializeComponent();
        }

        private void Loglar_Load(object sender, EventArgs e)
        {
            LoglarıGoruntule();
        }

        public void LoglarıGoruntule()
        {

            try
            {
                // Veritabanı sorgusu (Loglar tablosu)
                string sorgu = "SELECT * FROM Loglar";

                // Veritabanı bağlantısı
                SqlDataAdapter veriler = new SqlDataAdapter(sorgu, baglanti);

                // DataTable oluştur
                DataTable tablo = new DataTable();

                // Verileri DataTable'a yükle
                veriler.Fill(tablo);

                // DataGridView'e DataTable'ı bağla
                dataGridView1.DataSource = tablo;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loglar getirilirken hata oluştu: " + ex.Message);
                Log.Error("Loglar getirilemedi.", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
