namespace StokTakipSistemi
{
    partial class FaturaGortuntule
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
            dgvFatura = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFatura).BeginInit();
            SuspendLayout();
            // 
            // dgvFatura
            // 
            dgvFatura.BackgroundColor = Color.SeaShell;
            dgvFatura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFatura.Location = new Point(22, 31);
            dgvFatura.Name = "dgvFatura";
            dgvFatura.RowHeadersWidth = 51;
            dgvFatura.RowTemplate.Height = 29;
            dgvFatura.Size = new Size(666, 559);
            dgvFatura.TabIndex = 0;
            // 
            // FaturaGortuntule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2024_11_06_120050;
            ClientSize = new Size(713, 613);
            Controls.Add(dgvFatura);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FaturaGortuntule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FaturaGortuntule";
            Load += FaturaGortuntule_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFatura).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFatura;
    }
}