using System.Windows.Forms;

namespace KisiDefteri
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler = new List<Kisi>();
        public Form1()
        {
            InitializeComponent();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "")
                MessageBox.Show("Lütfen Ad veya Soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Kisi yeniKisi = new Kisi() { Ad = txtAd.Text, Soyad = txtSoyad.Text };
                kisiler.Add(yeniKisi);

                lstKisiler.Items.Add(yeniKisi);
                lstKisiler.Update();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Kisi secilenKisi = (Kisi)lstKisiler.SelectedItem;

            kisiler.Remove(secilenKisi);
            lstKisiler.Items.Remove(secilenKisi);
            lstKisiler.Update();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Kisi kisi = (Kisi)lstKisiler.SelectedItem;
            Form2 frmDuzenle = new Form2(kisi);
            frmDuzenle.Owner = this;
            frmDuzenle.ShowDialog();

            
        }
    }
}