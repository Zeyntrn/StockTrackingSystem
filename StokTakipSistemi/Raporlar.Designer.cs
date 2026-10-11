namespace StokTakipSistemi
{
    partial class Raporlar
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dgvRapor = new DataGridView();
            btnSatisprsnl = new Button();
            txtsatisyapanersonel = new TextBox();
            datetimeZaman = new DateTimePicker();
            btnSatisGetir = new Button();
            btnTumFaturalar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRapor).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Z_E_Y_N__2_;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(189, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // dgvRapor
            // 
            dgvRapor.BackgroundColor = Color.SeaShell;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvRapor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvRapor.DefaultCellStyle = dataGridViewCellStyle5;
            dgvRapor.GridColor = Color.Black;
            dgvRapor.Location = new Point(486, 90);
            dgvRapor.Name = "dgvRapor";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvRapor.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvRapor.RowHeadersWidth = 51;
            dgvRapor.RowTemplate.Height = 29;
            dgvRapor.Size = new Size(1092, 743);
            dgvRapor.TabIndex = 8;
            // 
            // btnSatisprsnl
            // 
            btnSatisprsnl.BackColor = Color.SeaShell;
            btnSatisprsnl.FlatAppearance.BorderColor = Color.Black;
            btnSatisprsnl.FlatStyle = FlatStyle.Flat;
            btnSatisprsnl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSatisprsnl.ForeColor = Color.SaddleBrown;
            btnSatisprsnl.Location = new Point(92, 211);
            btnSatisprsnl.Name = "btnSatisprsnl";
            btnSatisprsnl.Size = new Size(285, 35);
            btnSatisprsnl.TabIndex = 44;
            btnSatisprsnl.Text = "En Çok Satış Yapan Personel";
            btnSatisprsnl.TextAlign = ContentAlignment.TopCenter;
            btnSatisprsnl.UseVisualStyleBackColor = false;
            btnSatisprsnl.Click += btnSatisprsnl_Click;
            // 
            // txtsatisyapanersonel
            // 
            txtsatisyapanersonel.BackColor = Color.SeaShell;
            txtsatisyapanersonel.Enabled = false;
            txtsatisyapanersonel.Location = new Point(92, 270);
            txtsatisyapanersonel.Name = "txtsatisyapanersonel";
            txtsatisyapanersonel.Size = new Size(285, 27);
            txtsatisyapanersonel.TabIndex = 45;
            // 
            // datetimeZaman
            // 
            datetimeZaman.CalendarTitleBackColor = SystemColors.ActiveBorder;
            datetimeZaman.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            datetimeZaman.Location = new Point(92, 378);
            datetimeZaman.Name = "datetimeZaman";
            datetimeZaman.Size = new Size(250, 27);
            datetimeZaman.TabIndex = 46;
            // 
            // btnSatisGetir
            // 
            btnSatisGetir.BackColor = Color.SeaShell;
            btnSatisGetir.FlatAppearance.BorderColor = Color.Black;
            btnSatisGetir.FlatStyle = FlatStyle.Flat;
            btnSatisGetir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSatisGetir.ForeColor = Color.SaddleBrown;
            btnSatisGetir.Location = new Point(348, 370);
            btnSatisGetir.Name = "btnSatisGetir";
            btnSatisGetir.Size = new Size(56, 35);
            btnSatisGetir.TabIndex = 47;
            btnSatisGetir.Text = "✔";
            btnSatisGetir.TextAlign = ContentAlignment.TopCenter;
            btnSatisGetir.UseVisualStyleBackColor = false;
            btnSatisGetir.Click += btnSatisGetir_Click;
            // 
            // btnTumFaturalar
            // 
            btnTumFaturalar.BackColor = Color.SeaShell;
            btnTumFaturalar.FlatAppearance.BorderColor = Color.Black;
            btnTumFaturalar.FlatStyle = FlatStyle.Flat;
            btnTumFaturalar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTumFaturalar.ForeColor = Color.SaddleBrown;
            btnTumFaturalar.Location = new Point(92, 474);
            btnTumFaturalar.Name = "btnTumFaturalar";
            btnTumFaturalar.Size = new Size(285, 35);
            btnTumFaturalar.TabIndex = 48;
            btnTumFaturalar.Text = "Tüm Faturaları Göster";
            btnTumFaturalar.TextAlign = ContentAlignment.TopCenter;
            btnTumFaturalar.UseVisualStyleBackColor = false;
            btnTumFaturalar.Click += button1_Click;
            // 
            // Raporlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(1614, 854);
            Controls.Add(btnTumFaturalar);
            Controls.Add(btnSatisGetir);
            Controls.Add(datetimeZaman);
            Controls.Add(txtsatisyapanersonel);
            Controls.Add(btnSatisprsnl);
            Controls.Add(dgvRapor);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlDark;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Raporlar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlar";
            WindowState = FormWindowState.Maximized;
            Load += Raporlar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvRapor;
        private Button btnSatisprsnl;
        private TextBox txtsatisyapanersonel;
        private DateTimePicker datetimeZaman;
        private Button btnSatisGetir;
        private Button btnTumFaturalar;
    }
}