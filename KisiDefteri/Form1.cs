using System.Drawing.Design;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Forms;

namespace KisiDefteri
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler;

        public Form1()
        {
            InitializeComponent();
            VerileriYukle();
            KisileriListele();
        }

        private void VerileriYukle()
        {
            try
            {
                string json = File.ReadAllText("veri.json");
                kisiler = JsonSerializer.Deserialize<List<Kisi>>(json)!;
            }
            catch (Exception)
            {

                kisiler = OrnekVeriler();
            }
        }

        private List<Kisi> OrnekVeriler()
        {
            return kisiler = new List<Kisi> {
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
                DialogResult dr = MessageBox.Show(lstKisiler.SelectedItem + " Silinecek. Emin misiniz?", "Silme Onayý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    int currentIndex = lstKisiler.SelectedIndex;
                    Kisi secilenKisi = (Kisi)lstKisiler.SelectedItem;

                    kisiler.Remove(secilenKisi);
                    KisileriListele();

                    if (currentIndex < lstKisiler.Items.Count)
                        lstKisiler.SelectedIndex = currentIndex;
                    else
                        lstKisiler.SelectedIndex = currentIndex - 1;

                    //Kisi secilenKisi = (Kisi)lstKisiler.SelectedItem;
                    //int sid = lstKisiler.SelectedIndex;

                    //kisiler.Remove(secilenKisi);
                    //KisileriListele();

                    //lstKisiler.SelectedIndex = Math.Min(sid, kisiler.Count - 1);
                }
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

                ;
                frmDuzenle.Owner = this;
                frmDuzenle.ShowDialog();

                KisileriListele();
                lstKisiler.SelectedItem = kisi;
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

        private void lstKisiler_DoubleClick(object sender, EventArgs e)
        {
            btnDuzenle.PerformClick();
        }

        private void lstKisiler_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete))
            {
                btnSil.PerformClick();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true

            };

            string json = JsonSerializer.Serialize(kisiler, options);
            File.WriteAllText("veri.json", json);
        }
    }
}