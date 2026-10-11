namespace StokTakipSistemi
{
    partial class SifreDegistir
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
            txtMail = new TextBox();
            label2 = new Label();
            txtSifre = new TextBox();
            btnDegistir = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(44, 78);
            label1.Name = "label1";
            label1.Size = new Size(76, 23);
            label1.TabIndex = 0;
            label1.Text = "E-Mail : ";
            // 
            // txtMail
            // 
            txtMail.BackColor = Color.SeaShell;
            txtMail.Location = new Point(126, 74);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(276, 27);
            txtMail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(20, 139);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Yeni Şifre : ";
            // 
            // txtSifre
            // 
            txtSifre.BackColor = Color.SeaShell;
            txtSifre.Location = new Point(126, 138);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(276, 27);
            txtSifre.TabIndex = 3;
            // 
            // btnDegistir
            // 
            btnDegistir.BackColor = SystemColors.ActiveCaptionText;
            btnDegistir.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btnDegistir.FlatAppearance.BorderColor = Color.Black;
            btnDegistir.FlatStyle = FlatStyle.Flat;
            btnDegistir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDegistir.Location = new Point(210, 196);
            btnDegistir.Name = "btnDegistir";
            btnDegistir.Size = new Size(113, 31);
            btnDegistir.TabIndex = 14;
            btnDegistir.Text = "Değiştir";
            btnDegistir.TextAlign = ContentAlignment.TopCenter;
            btnDegistir.UseVisualStyleBackColor = false;
            btnDegistir.Click += button1_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = SystemColors.ActiveCaptionText;
            btnCikis.BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_1148131;
            btnCikis.FlatAppearance.BorderColor = Color.Black;
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCikis.Location = new Point(408, 12);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(64, 31);
            btnCikis.TabIndex = 17;
            btnCikis.Text = "X";
            btnCikis.TextAlign = ContentAlignment.TopCenter;
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += button2_Click;
            // 
            // SifreDegistir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(484, 269);
            Controls.Add(btnCikis);
            Controls.Add(btnDegistir);
            Controls.Add(txtSifre);
            Controls.Add(label2);
            Controls.Add(txtMail);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SifreDegistir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ŞifremiGüncelle";
            Load += Form12_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMail;
        private Label label2;
        private TextBox txtSifre;
        private Button btnDegistir;
        private Button btnCikis;
    }
}