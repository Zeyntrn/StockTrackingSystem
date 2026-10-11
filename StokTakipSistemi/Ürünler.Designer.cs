namespace StokTakipSistemi
{
    partial class Ürünler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dgvUrunler = new DataGridView();
            txtAlısFiyat = new TextBox();
            txtUrunAd = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtBirimFiyat = new TextBox();
            btnTemizle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnEkle = new Button();
            label1 = new Label();
            cmbAltKategori = new ComboBox();
            label3 = new Label();
            txtFotoAdres = new TextBox();
            btnListele = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Z_E_Y_N__2_;
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 227);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // dgvUrunler
            // 
            dgvUrunler.BackgroundColor = Color.SeaShell;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUrunler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvUrunler.DefaultCellStyle = dataGridViewCellStyle4;
            dgvUrunler.Location = new Point(669, 253);
            dgvUrunler.Name = "dgvUrunler";
            dgvUrunler.RowHeadersWidth = 51;
            dgvUrunler.RowTemplate.Height = 29;
            dgvUrunler.Size = new Size(1010, 513);
            dgvUrunler.TabIndex = 4;
            dgvUrunler.CellContentClick += dataGridView1_CellContentClick;
            dgvUrunler.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // txtAlısFiyat
            // 
            txtAlısFiyat.BackColor = Color.SeaShell;
            txtAlısFiyat.Location = new Point(404, 445);
            txtAlısFiyat.Multiline = true;
            txtAlısFiyat.Name = "txtAlısFiyat";
            txtAlısFiyat.Size = new Size(192, 32);
            txtAlısFiyat.TabIndex = 36;
            txtAlısFiyat.KeyPress += txtAlısFiyat_KeyPress;
            // 
            // txtUrunAd
            // 
            txtUrunAd.BackColor = Color.SeaShell;
            txtUrunAd.Location = new Point(404, 302);
            txtUrunAd.Multiline = true;
            txtUrunAd.Name = "txtUrunAd";
            txtUrunAd.Size = new Size(192, 32);
            txtUrunAd.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(214, 445);
            label5.Name = "label5";
            label5.Size = new Size(134, 32);
            label5.TabIndex = 22;
            label5.Text = "Alış Fiyatı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(201, 395);
            label4.Name = "label4";
            label4.Size = new Size(153, 32);
            label4.TabIndex = 21;
            label4.Text = "Birim Fiyatı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(222, 302);
            label2.Name = "label2";
            label2.Size = new Size(125, 32);
            label2.TabIndex = 19;
            label2.Text = "Ürün Adı :";
            // 
            // txtBirimFiyat
            // 
            txtBirimFiyat.BackColor = Color.SeaShell;
            txtBirimFiyat.Location = new Point(404, 395);
            txtBirimFiyat.Multiline = true;
            txtBirimFiyat.Name = "txtBirimFiyat";
            txtBirimFiyat.Size = new Size(192, 32);
            txtBirimFiyat.TabIndex = 28;
            txtBirimFiyat.KeyPress += txtBirimFiyat_KeyPress;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.SeaShell;
            btnTemizle.FlatAppearance.BorderColor = Color.Black;
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnTemizle.ForeColor = Color.SaddleBrown;
            btnTemizle.Location = new Point(465, 688);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(131, 46);
            btnTemizle.TabIndex = 32;
            btnTemizle.Text = "TEMİZLE";
            btnTemizle.TextAlign = ContentAlignment.TopCenter;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += button4_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.SeaShell;
            btnGuncelle.FlatAppearance.BorderColor = Color.Black;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuncelle.ForeColor = Color.SaddleBrown;
            btnGuncelle.Location = new Point(252, 688);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(131, 46);
            btnGuncelle.TabIndex = 31;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.TextAlign = ContentAlignment.TopCenter;
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += button3_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.SeaShell;
            btnSil.FlatAppearance.BorderColor = Color.Black;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSil.ForeColor = Color.SaddleBrown;
            btnSil.Location = new Point(465, 624);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(131, 46);
            btnSil.TabIndex = 30;
            btnSil.Text = "SİL";
            btnSil.TextAlign = ContentAlignment.TopCenter;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += button2_Click;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.SeaShell;
            btnEkle.FlatAppearance.BorderColor = Color.Black;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEkle.ForeColor = Color.SaddleBrown;
            btnEkle.Location = new Point(253, 624);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(131, 46);
            btnEkle.TabIndex = 29;
            btnEkle.Text = "EKLE";
            btnEkle.TextAlign = ContentAlignment.TopCenter;
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(196, 348);
            label1.Name = "label1";
            label1.Size = new Size(187, 32);
            label1.TabIndex = 35;
            label1.Text = "AltKategoriAdı :";
            // 
            // cmbAltKategori
            // 
            cmbAltKategori.BackColor = Color.SeaShell;
            cmbAltKategori.FormattingEnabled = true;
            cmbAltKategori.Location = new Point(404, 351);
            cmbAltKategori.Name = "cmbAltKategori";
            cmbAltKategori.Size = new Size(192, 28);
            cmbAltKategori.TabIndex = 37;
            cmbAltKategori.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(196, 488);
            label3.Name = "label3";
            label3.Size = new Size(193, 32);
            label3.TabIndex = 38;
            label3.Text = "Fotoğraf Adresi :";
            // 
            // txtFotoAdres
            // 
            txtFotoAdres.BackColor = Color.SeaShell;
            txtFotoAdres.Location = new Point(404, 492);
            txtFotoAdres.Multiline = true;
            txtFotoAdres.Name = "txtFotoAdres";
            txtFotoAdres.Size = new Size(192, 35);
            txtFotoAdres.TabIndex = 39;
            // 
            // btnListele
            // 
            btnListele.BackColor = Color.Transparent;
            btnListele.FlatAppearance.BorderColor = Color.Black;
            btnListele.FlatStyle = FlatStyle.Flat;
            btnListele.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnListele.ForeColor = SystemColors.ControlText;
            btnListele.Location = new Point(669, 181);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(139, 46);
            btnListele.TabIndex = 40;
            btnListele.Text = "LİSTELE";
            btnListele.TextAlign = ContentAlignment.TopCenter;
            btnListele.UseVisualStyleBackColor = false;
            btnListele.Click += button5_Click;
            // 
            // Ürünler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(1752, 858);
            Controls.Add(btnListele);
            Controls.Add(txtFotoAdres);
            Controls.Add(label3);
            Controls.Add(cmbAltKategori);
            Controls.Add(label1);
            Controls.Add(btnTemizle);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(txtAlısFiyat);
            Controls.Add(txtBirimFiyat);
            Controls.Add(txtUrunAd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(dgvUrunler);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Ürünler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürünler";
            WindowState = FormWindowState.Maximized;
            Load += Ürünler_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUrunler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvUrunler;
        private TextBox txtAlısFiyat;
        private TextBox txtBirimFiyat;
        private TextBox txtUrunAd;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtFotoAdres;
        private Button btnTemizle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnEkle;
        private Label label1;
        private ComboBox cmbAltKategori;
        private Button btnListele;
    }
}