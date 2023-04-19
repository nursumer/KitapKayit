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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Urun yeni = new Urun();
            yeni.UrunKodu = txtUrunKodu.Text;
            yeni.UrunAdi = txtUrunAdi.Text;
            yeni.Fiyati = nuFiyati.Value;
            yeni.StokMiktari = (int)nuStok.Value;
            yeni.UretimTarihi = dtpUretimTarihi.Value;
            yeni.GarantiSuresi = (int)nuGaranti.Value;

            string[] satirBilgisi = { yeni.UrunKodu, yeni.UrunAdi, yeni.Fiyati.ToString(), yeni.StokMiktari.ToString(), yeni.UretimTarihi.ToString(), yeni.GarantiSuresi.ToString() };
            ListViewItem lvi = new ListViewItem(satirBilgisi); // listview item tipinde 
            lvi.Tag = yeni;
            listView1.Items.Add(lvi);

            Temizle();

        }
        private void Temizle()
        {

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
            dtpUretimTarihi.ResetText();
            nuFiyati.ResetText();
            nuGaranti.ResetText();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            secili.UrunKodu = txtUrunKodu.Text;
            secili.UrunAdi = txtUrunAdi.Text;
            secili.Fiyati = nuFiyati.Value;
            secili.StokMiktari = (int)nuStok.Value;
            secili.UretimTarihi = dtpUretimTarihi.Value;
            secili.GarantiSuresi = (int)nuGaranti.Value;

            string[] satirBilgisi = { secili.UrunKodu, secili.UrunAdi, secili.Fiyati.ToString(), secili.StokMiktari.ToString(), secili.UretimTarihi.ToString(), secili.GarantiSuresi.ToString() };
            ListViewItem lvi = new ListViewItem(satirBilgisi);
            lvi.Tag = secili;


            int index = listView1.SelectedItems[0].Index;
            listView1.Items.RemoveAt(index);
            listView1.Items.Insert(index, lvi);
            Temizle();


        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        Urun secili;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;

        }

        private void listView1_Click(object sender, EventArgs e)
        {

            secili = (Urun)listView1.SelectedItems[0].Tag;
            txtUrunKodu.Text = secili.UrunKodu;
            txtUrunAdi.Text = secili.UrunAdi;
            nuFiyati.Value = secili.Fiyati;
            nuStok.Value = secili.StokMiktari;
            dtpUretimTarihi.Value = secili.UretimTarihi;
            nuGaranti.Value = secili.GarantiSuresi;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems[0].Index != -1)
            //{
            //    int index = listView1.SelectedItems[0].Index;
            //    listView1.Items.RemoveAt(index);
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen bir seçim yapın");
            //}
            if(listView1.Items.Count>0)
            {
                int index = listView1.SelectedItems[0].Index;
                listView1.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Lütfen bir seçim yapın");
            }
   
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
