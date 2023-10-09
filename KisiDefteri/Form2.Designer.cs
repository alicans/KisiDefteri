namespace KisiDefteri
{
    partial class Form2
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
            btnKaydett = new Button();
            txtAdi = new TextBox();
            txtSoyadi = new TextBox();
            label2 = new Label();
            btnIptal = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 40);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 0;
            label1.Text = "Ad:";
            // 
            // btnKaydett
            // 
            btnKaydett.Location = new Point(25, 120);
            btnKaydett.Name = "btnKaydett";
            btnKaydett.Size = new Size(96, 32);
            btnKaydett.TabIndex = 1;
            btnKaydett.Text = "Kaydet";
            btnKaydett.UseVisualStyleBackColor = true;
            // 
            // txtAdi
            // 
            txtAdi.Location = new Point(73, 37);
            txtAdi.Name = "txtAdi";
            txtAdi.Size = new Size(158, 23);
            txtAdi.TabIndex = 2;
            // 
            // txtSoyadi
            // 
            txtSoyadi.Location = new Point(73, 78);
            txtSoyadi.Name = "txtSoyadi";
            txtSoyadi.Size = new Size(158, 23);
            txtSoyadi.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 81);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Soyad:";
            // 
            // btnIptal
            // 
            btnIptal.Location = new Point(127, 120);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(104, 32);
            btnIptal.TabIndex = 5;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 177);
            Controls.Add(btnIptal);
            Controls.Add(txtSoyadi);
            Controls.Add(label2);
            Controls.Add(txtAdi);
            Controls.Add(btnKaydett);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Düzenle";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnKaydett;
        private TextBox txtAdi;
        private TextBox txtSoyadi;
        private Label label2;
        private Button btnIptal;
    }
}