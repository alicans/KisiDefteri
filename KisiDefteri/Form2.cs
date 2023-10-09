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
        public Form2(Kisi? kisi)
        {
            InitializeComponent();
            
            txtAdi.Text = kisi.Ad.ToString();
            txtSoyadi.Text = kisi.Soyad.ToString();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
