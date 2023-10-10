using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KisiDefteri
{
    public partial class Form2 : Form
    {
        private readonly Kisi _kisi;
        public Form2(Kisi kisi)
        {
            _kisi = kisi;
            InitializeComponent();

            txtAdi.Text = kisi.Ad;
            txtSoyadi.Text = kisi.Soyad;
        }


        private void btnKaydett_Click(object sender, EventArgs e)
        {
            string ad = txtAdi.Text.Trim();
            string soyad = txtSoyadi.Text.Trim();

            if (ad == "" || soyad == "")
            {
                MessageBox.Show("Lütfen Ad veya Soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                _kisi.Ad = ad;
                _kisi.Soyad = soyad;
                this.Close();

            }





        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
