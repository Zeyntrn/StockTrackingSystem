namespace StokTakipSistemi
{
    partial class KullaniciGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciGiris));
            txtkullaniciSifre = new TextBox();
            txtkullaniciAd = new TextBox();
            label3 = new Label();
            label2 = new Label();
            lnkkayitOl = new LinkLabel();
            btngiris = new Button();
            lnksifreUnuttum = new LinkLabel();
            btncikis = new Button();
            SuspendLayout();
            // 
            // txtkullaniciSifre
            // 
            txtkullaniciSifre.BackColor = Color.SeaShell;
            txtkullaniciSifre.Location = new Point(245, 415);
            txtkullaniciSifre.Name = "txtkullaniciSifre";
            txtkullaniciSifre.Size = new Size(186, 27);
            txtkullaniciSifre.TabIndex = 12;
            // 
            // txtkullaniciAd
            // 
            txtkullaniciAd.BackColor = Color.SeaShell;
            txtkullaniciAd.Location = new Point(245, 369);
            txtkullaniciAd.Name = "txtkullaniciAd";
            txtkullaniciAd.Size = new Size(186, 27);
            txtkullaniciAd.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(96, 419);
            label3.Name = "label3";
            label3.Size = new Size(128, 23);
            label3.TabIndex = 10;
            label3.Text = "Kullanıcı Şifre :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(100, 373);
            label2.Name = "label2";
            label2.Size = new Size(124, 23);
            label2.TabIndex = 9;
            label2.Text = "Kullanıcı Adı  :";
            // 
            // lnkkayitOl
            // 
            lnkkayitOl.AutoSize = true;
            lnkkayitOl.BackColor = Color.Transparent;
            lnkkayitOl.LinkColor = Color.DarkGray;
            lnkkayitOl.Location = new Point(239, 475);
            lnkkayitOl.Name = "lnkkayitOl";
            lnkkayitOl.Size = new Size(65, 20);
            lnkkayitOl.TabIndex = 13;
            lnkkayitOl.TabStop = true;
            lnkkayitOl.Text = "Kayıt Ol ";
            lnkkayitOl.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btngiris
            // 
            btngiris.BackColor = SystemColors.ActiveCaptionText;
            btngiris.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btngiris.FlatAppearance.BorderColor = Color.Black;
            btngiris.FlatStyle = FlatStyle.Flat;
            btngiris.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btngiris.Location = new Point(268, 527);
            btngiris.Name = "btngiris";
            btngiris.Size = new Size(113, 31);
            btngiris.TabIndex = 14;
            btngiris.Text = "Giriş ";
            btngiris.TextAlign = ContentAlignment.TopCenter;
            btngiris.UseVisualStyleBackColor = false;
            btngiris.Click += button1_Click;
            // 
            // lnksifreUnuttum
            // 
            lnksifreUnuttum.AutoSize = true;
            lnksifreUnuttum.BackColor = Color.Transparent;
            lnksifreUnuttum.LinkColor = Color.DarkGray;
            lnksifreUnuttum.Location = new Point(310, 475);
            lnksifreUnuttum.Name = "lnksifreUnuttum";
            lnksifreUnuttum.Size = new Size(121, 20);
            lnksifreUnuttum.TabIndex = 15;
            lnksifreUnuttum.TabStop = true;
            lnksifreUnuttum.Text = "Şifremi Unuttum ";
            lnksifreUnuttum.LinkClicked += linkLabel2_LinkClicked;
            // 
            // btncikis
            // 
            btncikis.BackColor = SystemColors.ActiveCaptionText;
            btncikis.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btncikis.FlatAppearance.BorderColor = Color.Black;
            btncikis.FlatStyle = FlatStyle.Flat;
            btncikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btncikis.Location = new Point(458, 12);
            btncikis.Name = "btncikis";
            btncikis.Size = new Size(64, 31);
            btncikis.TabIndex = 16;
            btncikis.Text = "X";
            btncikis.TextAlign = ContentAlignment.TopCenter;
            btncikis.UseVisualStyleBackColor = false;
            btncikis.Click += button2_Click;
            // 
            // KullaniciGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(534, 695);
            Controls.Add(btncikis);
            Controls.Add(lnksifreUnuttum);
            Controls.Add(btngiris);
            Controls.Add(lnkkayitOl);
            Controls.Add(txtkullaniciSifre);
            Controls.Add(txtkullaniciAd);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KullaniciGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KullaniciGiris";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtkullaniciSifre;
        private TextBox txtkullaniciAd;
        private Label label3;
        private Label label2;
        private LinkLabel lnkkayitOl;
        private Button btngiris;
        private LinkLabel lnksifreUnuttum;
        private Button btncikis;
    }
}