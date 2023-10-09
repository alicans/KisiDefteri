using System.Security.Cryptography;
using System.Windows.Forms;

namespace KisiDefteri
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler;

        public Form1()
        {
            InitializeComponent();
            OrnekVerileriYukle();
            KisileriListele();
        }

        private void OrnekVerileriYukle()
        {
            kisiler = new List<Kisi> {
                new Kisi() { Ad = "Ali", Soyad = "Yýlmaz" },
                new Kisi() { Ad = "Can", Soyad = "Öztürk" },
                new Kisi() { Ad = "Cem", Soyad = "Þahin" },
                new Kisi() { Ad = "Ece", Soyad = "Doðan" }
            };
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "")
            {
                MessageBox.Show("Lütfen Ad veya Soyad giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Kisi yeniKisi = new Kisi() { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim() };
                kisiler.Add(yeniKisi);
                KisileriListele();
                lstKisiler.SelectedItem = yeniKisi;

                txtAd.Text = txtSoyad.Text = "";
                txtAd.Focus();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstKisiler.SelectedItem != null)
            {
                Kisi secilenKisi = (Kisi)lstKisiler.SelectedItem;
                int sid = lstKisiler.SelectedIndex;

                kisiler.Remove(secilenKisi);
                KisileriListele();

                lstKisiler.SelectedIndex = Math.Min(sid, kisiler.Count - 1);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kiþiyi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnYukari_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;

            if (sid > 0)
                SeciliyiTasi(sid - 1);
            else return;
        }
        private void btnAsagi_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;

            if (sid < 0 || sid > kisiler.Count - 2) return;
            else SeciliyiTasi(sid + 1);
        }

        private void SeciliyiTasi(int yeniIndex)
        {
            Kisi secilen = (Kisi)lstKisiler.SelectedItem;

            kisiler.Remove(secilen);
            kisiler.Insert(yeniIndex, secilen);

            KisileriListele();

            lstKisiler.SelectedItem = secilen;
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


        private void KisileriListele()
        {
            lstKisiler.Items.Clear();

            foreach (Kisi kisi in kisiler)
                lstKisiler.Items.Add(kisi);

            lstKisiler.Update();

        }

    }
}