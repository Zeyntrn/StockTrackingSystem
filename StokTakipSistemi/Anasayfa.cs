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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokTakipSistemi
{
    public partial class Anasayfa : Form
    {
        private KullaniciYetkileri kullaniciYetkileri;
        public Anasayfa(string kullaniciTuru)
        {

            InitializeComponent();
            kullaniciYetkileri = new KullaniciYetkileri(kullaniciTuru);


        }
       

        public string KullaniciTuru { get; private set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcılar yeniform = new Kullanıcılar();
            yeniform.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Raporlar yeniform = new Raporlar();
            yeniform.ShowDialog();


        }

        private void button6_Click(object sender, EventArgs e)
        {

            Loglar yeniform = new Loglar();
            yeniform.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori yeniform = new Kategori();
            yeniform.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ürünler yeniform = new Ürünler();
            yeniform.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StokKontrol yeniform = new StokKontrol();
            yeniform.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Satışİşlemleri yeniform = new Satışİşlemleri();
            yeniform.ShowDialog();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if ( kullaniciYetkileri.KullaniciTuru == "Yönetici")
            {
                btnKullanicilar.Enabled = true;
                btnRapor.Enabled = true;
                btnLoglar.Enabled = true;
            }
            else if (kullaniciYetkileri.KullaniciTuru == "Personel")
            {
                btnKullanicilar.Enabled = false;
                btnRapor.Enabled = false;
                btnLoglar.Enabled = false;
            }



        } 

        private void button8_Click(object sender, EventArgs e)
        {
            KullaniciGiris geridon = new KullaniciGiris();
            geridon.Show();
            this.Hide();
        }


    }
}
