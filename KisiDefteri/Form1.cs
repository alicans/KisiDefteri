using System.Windows.Forms;

namespace KisiDefteri
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler = new List<Kisi>();
        public Form1()
        {
            InitializeComponent();
            Listele();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "")
                MessageBox.Show("Lütfen Ad veya Soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Kisi yeniKisi = new Kisi() { Ad = txtAd.Text, Soyad = txtSoyad.Text };
                kisiler.Add(yeniKisi);

                Listele();
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
            if (lstKisiler.SelectedItem != null)
            {
                Kisi kisi = (Kisi)lstKisiler.SelectedItem;
                Form2 frmDuzenle = new Form2(kisi);
                frmDuzenle.GidenKisi = kisi;
                frmDuzenle.Owner = this;
                frmDuzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek kiþiyi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnYukari_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;

            if (sid > 0)
            {
                Kisi secilen = kisiler[sid];

                kisiler.RemoveAt(sid);
                kisiler.Insert(sid - 1, secilen);

                Listele();
                lstKisiler.SelectedIndex = sid - 1;
            }
        }

        private void Listele()
        {
            lstKisiler.Items.Clear();

            foreach (Kisi kisi in kisiler)
                lstKisiler.Items.Add(kisi);

            lstKisiler.Update();

        }

        private void btnAsagi_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;
            if (sid < 0 || sid > kisiler.Count - 2) return;

            Kisi secilen = kisiler[sid];
            kisiler.RemoveAt(sid);
            kisiler.Insert(sid + 1, secilen);
            Listele();
            lstKisiler.SelectedIndex = sid + 1;
        }
    }
}