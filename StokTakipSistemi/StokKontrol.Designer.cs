namespace StokTakipSistemi
{
    partial class StokKontrol
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
            pictureBox1 = new PictureBox();
            dgvStoklar = new DataGridView();
            label1 = new Label();
            label4 = new Label();
            txtMevcutStok = new TextBox();
            label2 = new Label();
            btnGuncelle = new Button();
            btnListele = new Button();
            cmbUrunSec = new ComboBox();
            cmbDepoSec = new ComboBox();
            label3 = new Label();
            txtMinStok = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Z_E_Y_N__2_;
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 209);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // dgvStoklar
            // 
            dgvStoklar.BackgroundColor = Color.SeaShell;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStoklar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStoklar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvStoklar.DefaultCellStyle = dataGridViewCellStyle2;
            dgvStoklar.GridColor = Color.Black;
            dgvStoklar.Location = new Point(679, 165);
            dgvStoklar.Name = "dgvStoklar";
            dgvStoklar.RowHeadersWidth = 51;
            dgvStoklar.RowTemplate.Height = 29;
            dgvStoklar.Size = new Size(1015, 643);
            dgvStoklar.TabIndex = 6;
            dgvStoklar.CellContentClick += dgvStoklar_CellContentClick;
            dgvStoklar.RowPrePaint += dgvStoklar_RowPrePaint;
            dgvStoklar.SelectionChanged += dgvStoklar_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(165, 375);
            label1.Name = "label1";
            label1.Size = new Size(128, 32);
            label1.TabIndex = 52;
            label1.Text = "Depo Adı :";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(165, 327);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 51;
            label4.Text = "Ürün Adı :";
            // 
            // txtMevcutStok
            // 
            txtMevcutStok.BackColor = Color.SeaShell;
            txtMevcutStok.Location = new Point(305, 428);
            txtMevcutStok.Name = "txtMevcutStok";
            txtMevcutStok.Size = new Size(225, 27);
            txtMevcutStok.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(135, 423);
            label2.Name = "label2";
            label2.Size = new Size(158, 32);
            label2.TabIndex = 49;
            label2.Text = "Stok Miktarı :";
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.SeaShell;
            btnGuncelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuncelle.ForeColor = Color.SaddleBrown;
            btnGuncelle.Location = new Point(340, 572);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(161, 59);
            btnGuncelle.TabIndex = 55;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += button1_Click;
            // 
            // btnListele
            // 
            btnListele.BackColor = Color.Transparent;
            btnListele.FlatStyle = FlatStyle.Flat;
            btnListele.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnListele.Location = new Point(679, 122);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(130, 37);
            btnListele.TabIndex = 57;
            btnListele.Text = "LİSTELE ";
            btnListele.UseVisualStyleBackColor = false;
            btnListele.Click += btnListele_Click;
            // 
            // cmbUrunSec
            // 
            cmbUrunSec.BackColor = Color.SeaShell;
            cmbUrunSec.FormattingEnabled = true;
            cmbUrunSec.Location = new Point(305, 327);
            cmbUrunSec.Name = "cmbUrunSec";
            cmbUrunSec.Size = new Size(225, 28);
            cmbUrunSec.TabIndex = 58;
            // 
            // cmbDepoSec
            // 
            cmbDepoSec.BackColor = Color.SeaShell;
            cmbDepoSec.FormattingEnabled = true;
            cmbDepoSec.Items.AddRange(new object[] { "Mağaza Depo " });
            cmbDepoSec.Location = new Point(305, 379);
            cmbDepoSec.Name = "cmbDepoSec";
            cmbDepoSec.Size = new Size(225, 28);
            cmbDepoSec.TabIndex = 59;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(24, 483);
            label3.Name = "label3";
            label3.Size = new Size(269, 32);
            label3.TabIndex = 60;
            label3.Text = "Minimum Stok Miktarı :";
            // 
            // txtMinStok
            // 
            txtMinStok.BackColor = Color.SeaShell;
            txtMinStok.Location = new Point(305, 485);
            txtMinStok.Name = "txtMinStok";
            txtMinStok.Size = new Size(225, 27);
            txtMinStok.TabIndex = 61;
            // 
            // StokKontrol
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(1672, 870);
            Controls.Add(txtMinStok);
            Controls.Add(label3);
            Controls.Add(cmbDepoSec);
            Controls.Add(cmbUrunSec);
            Controls.Add(btnListele);
            Controls.Add(btnGuncelle);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(txtMevcutStok);
            Controls.Add(label2);
            Controls.Add(dgvStoklar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "StokKontrol";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StokKontol";
            WindowState = FormWindowState.Maximized;
            Load += StokKontrol_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStoklar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvStoklar;
        private Label label1;
        private Label label4;
        private TextBox txtMevcutStok;
        private Label label2;
        private Button btnGuncelle;
        private Button btnListele;
        private ComboBox cmbUrunSec;
        private ComboBox cmbDepoSec;
        private Label label3;
        private TextBox txtMinStok;
    }
}