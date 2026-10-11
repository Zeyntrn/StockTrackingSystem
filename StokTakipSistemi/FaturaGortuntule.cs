using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class FaturaGortuntule : Form
    {
        private Fatura fatura;
        public FaturaGortuntule()
        {
            InitializeComponent();
            fatura = new Fatura();

        }

        private void FaturaGortuntule_Load(object sender, EventArgs e)
        {
            faturalar();
        }

        private void faturalar()
        {
            dgvFatura.DataSource = fatura.FaturalıGetir();

        }
    }
}
