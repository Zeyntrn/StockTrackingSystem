namespace StokTakipSistemi
{
    partial class KullanıcıKayıt
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtMail = new TextBox();
            cmbKullaniciTürü = new ComboBox();
            txtSifre = new TextBox();
            btnKayitOl = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Garamond", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(144, 111);
            label1.Name = "label1";
            label1.Size = new Size(225, 26);
            label1.TabIndex = 0;
            label1.Text = "KULLANICI KAYIT ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(144, 203);
            label2.Name = "label2";
            label2.Size = new Size(40, 23);
            label2.TabIndex = 1;
            label2.Text = "Ad :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(122, 249);
            label3.Name = "label3";
            label3.Size = new Size(66, 23);
            label3.TabIndex = 2;
            label3.Text = "Soyad :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(74, 297);
            label4.Name = "label4";
            label4.Size = new Size(128, 23);
            label4.TabIndex = 3;
            label4.Text = "Kullanıcı Türü :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(80, 339);
            label5.Name = "label5";
            label5.Size = new Size(119, 23);
            label5.TabIndex = 4;
            label5.Text = "Kullanıcı Adı :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(120, 386);
            label6.Name = "label6";
            label6.Size = new Size(69, 23);
            label6.TabIndex = 5;
            label6.Text = "E-Mail :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.Location = new Point(133, 432);
            label7.Name = "label7";
            label7.Size = new Size(54, 23);
            label7.TabIndex = 6;
            label7.Text = "Şifre :";
            label7.TextAlign = ContentAlignment.TopCenter;
            label7.Click += label7_Click;
            // 
            // txtAd
            // 
            txtAd.BackColor = Color.SeaShell;
            txtAd.Location = new Point(213, 200);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(151, 27);
            txtAd.TabIndex = 7;
            // 
            // txtSoyad
            // 
            txtSoyad.BackColor = Color.SeaShell;
            txtSoyad.Location = new Point(213, 246);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(151, 27);
            txtSoyad.TabIndex = 8;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.BackColor = Color.SeaShell;
            txtKullaniciAdi.Location = new Point(213, 336);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(151, 27);
            txtKullaniciAdi.TabIndex = 9;
            // 
            // txtMail
            // 
            txtMail.BackColor = Color.SeaShell;
            txtMail.Location = new Point(213, 383);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(151, 27);
            txtMail.TabIndex = 10;
            // 
            // cmbKullaniciTürü
            // 
            cmbKullaniciTürü.BackColor = Color.SeaShell;
            cmbKullaniciTürü.FormattingEnabled = true;
            cmbKullaniciTürü.Items.AddRange(new object[] { "Yönetici ", "Personel" });
            cmbKullaniciTürü.Location = new Point(213, 294);
            cmbKullaniciTürü.Name = "cmbKullaniciTürü";
            cmbKullaniciTürü.Size = new Size(151, 28);
            cmbKullaniciTürü.TabIndex = 11;
            cmbKullaniciTürü.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtSifre
            // 
            txtSifre.BackColor = Color.SeaShell;
            txtSifre.Location = new Point(213, 429);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(151, 27);
            txtSifre.TabIndex = 12;
            txtSifre.TextChanged += textBox5_TextChanged;
            // 
            // btnKayitOl
            // 
            btnKayitOl.BackColor = SystemColors.ActiveCaptionText;
            btnKayitOl.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btnKayitOl.FlatAppearance.BorderColor = Color.Black;
            btnKayitOl.FlatStyle = FlatStyle.Flat;
            btnKayitOl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKayitOl.Location = new Point(231, 508);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(113, 31);
            btnKayitOl.TabIndex = 13;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.TextAlign = ContentAlignment.TopCenter;
            btnKayitOl.UseVisualStyleBackColor = false;
            btnKayitOl.Click += button1_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = SystemColors.ActiveCaptionText;
            btnCikis.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btnCikis.FlatAppearance.BorderColor = Color.Black;
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCikis.Location = new Point(452, 12);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(64, 31);
            btnCikis.TabIndex = 17;
            btnCikis.Text = "X";
            btnCikis.TextAlign = ContentAlignment.TopCenter;
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += button2_Click;
            // 
            // KullanıcıKayıt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(534, 695);
            Controls.Add(btnCikis);
            Controls.Add(btnKayitOl);
            Controls.Add(txtSifre);
            Controls.Add(cmbKullaniciTürü);
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
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KullanıcıKayıt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KayıtEkranı";
            Load += KullanıcıKayıt_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtKullaniciAdi;
        private TextBox txtMail;
        private ComboBox cmbKullaniciTürü;
        private TextBox txtSifre;
        private Button btnKayitOl;
        private Button btnCikis;
    }
}