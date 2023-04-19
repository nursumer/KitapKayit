using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitap k = new Kitap();
            k.KitapAdi = txtKitapAdi.Text;
            k.Yazar = txtYazar.Text;
            k.ISBN = txtISBN.Text;
            k.Turu = txtTuru.Text;
            k.YayinEvi = txtYayinEvi.Text;
            k.YayinTarihi = dateTimePicker1.Value;
            //k.SayfaSayisi = (int)numericUpDown1.Value;
            k.SayfaSayisi = Convert.ToInt32(numericUpDown1.Value);
            // küçük tipten büyük tipe dönüştürürken cast kullanma
            lstKitaplar.Items.Add(k);// listbox collection olduğu için classta toString metodudunu override ediyoruz.
            Temizle();
        }

        private void Temizle()
        {

            //txtKitapAdi.Clear();
            //txtYazar.Clear();
            //txtISBN.Clear();
            //txtTuru.Clear();
            //txtYayinEvi.Clear();
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    {
                        TextBox txt = (TextBox)item;// itemler textbox tipinde gelecek
                        txt.Clear();
                    }
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now; 
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown nu = (NumericUpDown)item;
                    nu.Value = 0;
                }
            }
            dateTimePicker1.ResetText();
            numericUpDown1.ResetText();
        }
        Kitap secili; // kitap türünde seçili nesnesi
        private void lstKitaplar_DoubleClick(object sender, EventArgs e)
        {
            secili = (Kitap)lstKitaplar.SelectedItem; //listedeki kitap türündeki nesneleri secili aktar.
            txtKitapAdi.Text = secili.KitapAdi;
            txtYazar.Text = secili.Yazar;
            txtISBN.Text = secili.ISBN;
            txtTuru.Text = secili.Turu;
            txtYayinEvi.Text = secili.YayinEvi;
            dateTimePicker1.Value = secili.YayinTarihi;
            numericUpDown1.Value = secili.SayfaSayisi;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            secili.KitapAdi = txtKitapAdi.Text;
            secili.Yazar = txtYazar.Text;
            secili.ISBN = txtISBN.Text;
            secili.Turu = txtTuru.Text;
            secili.YayinEvi = txtYayinEvi.Text;
            secili.YayinTarihi = dateTimePicker1.Value;
            secili.SayfaSayisi = Convert.ToInt32(numericUpDown1.Value);

            int Index = lstKitaplar.SelectedIndex; //secilen indexi int index ata
            lstKitaplar.Items.RemoveAt(Index); //secilen indexi temizle
            lstKitaplar.Items.Insert(Index, secili); // insert ile güncelle
            Temizle();

        }

        private void lstKitaplar_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstKitaplar.SelectedIndex != -1) 
            {
                int Index = lstKitaplar.SelectedIndex;
                lstKitaplar.Items.RemoveAt(Index);
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen bir seçim yapın");
            }


           
        }
    }
}
