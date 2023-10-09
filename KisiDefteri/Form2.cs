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
        public Kisi GidenKisi;
        public Form2(Kisi kisi)
        {
            InitializeComponent();

            txtAdi.Text = kisi.Ad;
            txtSoyadi.Text = kisi.Soyad;
        }


        private void btnKaydett_Click(object sender, EventArgs e)
        {
            GidenKisi.Ad = txtAdi.Text;
            GidenKisi.Soyad = txtSoyadi.Text;

            this.Close();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
            Owner.Show();
        }


    }
}
