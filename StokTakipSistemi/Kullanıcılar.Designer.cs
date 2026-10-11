namespace StokTakipSistemi
{
    partial class Kullanıcılar
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtSifre = new TextBox();
            cmbKullaniciTuru = new ComboBox();
            txtMail = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            btnEkle = new Button();
            btnSil = new Button();
            btnGüncelle = new Button();
            btnTemizle = new Button();
            txtArama = new TextBox();
            btnAra = new Button();
            btnListele = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.SeaShell;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(151, 233);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(989, 694);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Z_E_Y_N__2_;
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.Location = new Point(1420, 599);
            label7.Name = "label7";
            label7.Size = new Size(75, 32);
            label7.TabIndex = 12;
            label7.Text = "Şifre :";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(1403, 547);
            label6.Name = "label6";
            label6.Size = new Size(97, 32);
            label6.TabIndex = 11;
            label6.Text = "E-Mail :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(1328, 500);
            label5.Name = "label5";
            label5.Size = new Size(167, 32);
            label5.TabIndex = 10;
            label5.Text = "Kullanıcı Adı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(1315, 452);
            label4.Name = "label4";
            label4.Size = new Size(180, 32);
            label4.TabIndex = 9;
            label4.Text = "Kullanıcı Türü :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(1403, 414);
            label3.Name = "label3";
            label3.Size = new Size(92, 32);
            label3.TabIndex = 8;
            label3.Text = "Soyad :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(1438, 367);
            label2.Name = "label2";
            label2.Size = new Size(57, 32);
            label2.TabIndex = 7;
            label2.Text = "Ad :";
            // 
            // txtSifre
            // 
            txtSifre.BackColor = Color.SeaShell;
            txtSifre.Location = new Point(1530, 599);
            txtSifre.Multiline = true;
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(183, 35);
            txtSifre.TabIndex = 18;
            // 
            // cmbKullaniciTuru
            // 
            cmbKullaniciTuru.BackColor = Color.SeaShell;
            cmbKullaniciTuru.FormattingEnabled = true;
            cmbKullaniciTuru.Items.AddRange(new object[] { "Yönetici", "Personel" });
            cmbKullaniciTuru.Location = new Point(1530, 458);
            cmbKullaniciTuru.Name = "cmbKullaniciTuru";
            cmbKullaniciTuru.Size = new Size(183, 28);
            cmbKullaniciTuru.TabIndex = 17;
            // 
            // txtMail
            // 
            txtMail.BackColor = Color.SeaShell;
            txtMail.Location = new Point(1530, 553);
            txtMail.Multiline = true;
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(183, 36);
            txtMail.TabIndex = 16;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.BackColor = Color.SeaShell;
            txtKullaniciAdi.Location = new Point(1530, 500);
            txtKullaniciAdi.Multiline = true;
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(183, 36);
            txtKullaniciAdi.TabIndex = 15;
            // 
            // txtSoyad
            // 
            txtSoyad.BackColor = Color.SeaShell;
            txtSoyad.Location = new Point(1530, 410);
            txtSoyad.Multiline = true;
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(183, 36);
            txtSoyad.TabIndex = 14;
            // 
            // txtAd
            // 
            txtAd.BackColor = Color.SeaShell;
            txtAd.Location = new Point(1530, 367);
            txtAd.Multiline = true;
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(183, 32);
            txtAd.TabIndex = 13;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.SeaShell;
            btnEkle.FlatAppearance.BorderColor = Color.Black;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEkle.ForeColor = Color.SaddleBrown;
            btnEkle.Location = new Point(1403, 692);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(130, 44);
            btnEkle.TabIndex = 19;
            btnEkle.Text = "EKLE";
            btnEkle.TextAlign = ContentAlignment.TopCenter;
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += button1_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.SeaShell;
            btnSil.FlatAppearance.BorderColor = Color.Black;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSil.ForeColor = Color.SaddleBrown;
            btnSil.Location = new Point(1589, 692);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(124, 44);
            btnSil.TabIndex = 20;
            btnSil.Text = "SİL";
            btnSil.TextAlign = ContentAlignment.TopCenter;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += button2_Click;
            // 
            // btnGüncelle
            // 
            btnGüncelle.BackColor = Color.SeaShell;
            btnGüncelle.FlatAppearance.BorderColor = Color.Black;
            btnGüncelle.FlatStyle = FlatStyle.Flat;
            btnGüncelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnGüncelle.ForeColor = Color.SaddleBrown;
            btnGüncelle.Location = new Point(1403, 774);
            btnGüncelle.Name = "btnGüncelle";
            btnGüncelle.Size = new Size(130, 41);
            btnGüncelle.TabIndex = 21;
            btnGüncelle.Text = "GÜNCELLE";
            btnGüncelle.TextAlign = ContentAlignment.TopCenter;
            btnGüncelle.UseVisualStyleBackColor = false;
            btnGüncelle.Click += button3_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.SeaShell;
            btnTemizle.FlatAppearance.BorderColor = Color.Black;
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnTemizle.ForeColor = Color.SaddleBrown;
            btnTemizle.Location = new Point(1589, 774);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(124, 41);
            btnTemizle.TabIndex = 22;
            btnTemizle.Text = "TEMİZLE";
            btnTemizle.TextAlign = ContentAlignment.TopCenter;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += button4_Click;
            // 
            // txtArama
            // 
            txtArama.BackColor = Color.SeaShell;
            txtArama.Location = new Point(254, 177);
            txtArama.Multiline = true;
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(200, 36);
            txtArama.TabIndex = 23;
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.SeaShell;
            btnAra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAra.Location = new Point(503, 177);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(73, 38);
            btnAra.TabIndex = 24;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += button5_Click;
            // 
            // btnListele
            // 
            btnListele.BackColor = SystemColors.ActiveCaptionText;
            btnListele.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btnListele.FlatAppearance.BorderColor = Color.Black;
            btnListele.FlatStyle = FlatStyle.Flat;
            btnListele.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnListele.Location = new Point(983, 171);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(126, 41);
            btnListele.TabIndex = 25;
            btnListele.Text = "Listele";
            btnListele.TextAlign = ContentAlignment.TopCenter;
            btnListele.UseVisualStyleBackColor = false;
            btnListele.Click += button6_Click;
            // 
            // Kullanıcılar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(1761, 1025);
            Controls.Add(btnListele);
            Controls.Add(btnAra);
            Controls.Add(txtArama);
            Controls.Add(btnTemizle);
            Controls.Add(btnGüncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(txtSifre);
            Controls.Add(cmbKullaniciTuru);
            Controls.Add(txtMail);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Kullanıcılar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcılar";
            WindowState = FormWindowState.Maximized;
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtSifre;
        private ComboBox cmbKullaniciTuru;
        private TextBox txtMail;
        private TextBox txtKullaniciAdi;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Button btnEkle;
        private Button btnSil;
        private Button btnGüncelle;
        private Button btnTemizle;
        private TextBox txtArama;
        private Button btnAra;
        private Button btnListele;
    }
}