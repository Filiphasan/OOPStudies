using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinnesLogicLayer;
using EntityLayer;
using FacadeLayer;
using System.Data;
using System.Data.SqlClient;

namespace Ogrenci_Not
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void OgrenciListesi()
        {
            List<EntityOgrenci> OgrList = BLLOgrenci.LISTELE();
            dataGridView1.DataSource = OgrList;
        }
        void KulupListesi()
        {
            List<EntityKulup> KulupList = BLLKulup.LISTELE();
            cmbogrkulup.DisplayMember = "KulupAd";
            cmbogrkulup.ValueMember = "KulupId";
            cmbogrkulup.DataSource = KulupList;
        }
        void KulupListele()
        {
            List<EntityKulup> KulupList = BLLKulup.LISTELE();
            dataGridView1.DataSource = KulupList;
        }
        void NotListesi()
        {
            List<EntityNotlar> NotList = BLLNotlar.LISTELE();
            dataGridView1.DataSource = NotList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
            this.Text = "Öğrenci Listesi";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListesi();
            KulupListesi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.AD = txtograd.Text;
            ent.SOYAD = txtogrsoyad.Text;
            ent.FOTOGRAF = txtogrfotograf.Text;
            ent.KULUPID =Convert.ToInt32(cmbogrkulup.SelectedValue);
            BLLOgrenci.EKLE(ent);
            OgrenciListesi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.ID =Convert.ToInt32(txtOgrId.Text);
            ent.AD = txtograd.Text;
            ent.SOYAD = txtogrsoyad.Text;
            ent.FOTOGRAF = txtogrfotograf.Text;
            ent.KULUPID =Convert.ToInt32(cmbogrkulup.SelectedValue);
            BLLOgrenci.GUNCELLE(ent);
            OgrenciListesi();
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text=="Öğrenci Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                txtOgrId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                txtograd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtogrsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtogrfotograf.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                cmbogrkulup.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
            if (this.Text=="Not Listesi")
            {
                int secilen2 = dataGridView1.SelectedCells[0].RowIndex;
                txtogrnotid.Text = dataGridView1.Rows[secilen2].Cells[0].Value.ToString();
                txtsinav1.Text = dataGridView1.Rows[secilen2].Cells[1].Value.ToString();
                txtsinav2.Text = dataGridView1.Rows[secilen2].Cells[2].Value.ToString();
                txtsinav3.Text = dataGridView1.Rows[secilen2].Cells[3].Value.ToString();
                txtproje.Text = dataGridView1.Rows[secilen2].Cells[4].Value.ToString();
                txtortalama.Text = dataGridView1.Rows[secilen2].Cells[5].Value.ToString();
                lbldurum.Text = dataGridView1.Rows[secilen2].Cells[6].Value.ToString();
            }
            if(this.Text=="Kulüp Listesi")
            {
                int secilen3 = dataGridView1.SelectedCells[0].RowIndex;
                txtkulupıd.Text = dataGridView1.Rows[secilen3].Cells[0].Value.ToString();
                txtkulupad.Text = dataGridView1.Rows[secilen3].Cells[1].Value.ToString();

            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            NotListesi();
            this.Text = "Not Listesi";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EntityNotlar ent = new EntityNotlar();
            ent.OGRID =Convert.ToInt32(txtogrnotid.Text);
            ent.SINAV1 = Convert.ToInt32(txtsinav1.Text);
            ent.SINAV2 = Convert.ToInt32(txtsinav2.Text);
            ent.SINAV3 = Convert.ToInt32(txtsinav3.Text);
            ent.PROJE = Convert.ToInt32(txtproje.Text);
            ent.ORTALAMA = Convert.ToInt32(txtortalama.Text);
            ent.DURUM = txtdurum.Text;
            BLLNotlar.GUNCELLE(ent);
            NotListesi();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Text = "Kulüp Listesi";
            KulupListele();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KULUPAD = txtkulupad.Text;
            BLLKulup.EKLE(ent);
            KulupListele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KULUPID = Convert.ToInt32(txtkulupıd.Text);
            ent.KULUPAD = txtkulupad.Text;
            BLLKulup.GUNCELLE(ent);
            KulupListele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ort;
            string durum;
            s1 = Convert.ToInt32(txtsinav1.Text);
            s2 = Convert.ToInt32(txtsinav2.Text);
            s3 = Convert.ToInt32(txtsinav3.Text);
            proje = Convert.ToInt32(txtproje.Text);
            ort = (s3 + s2 + s1 + proje) / 4;
            if (ort >= 50)
            {
                durum = "true";
                txtdurum.Text = durum;
            }
            if (ort < 50)
            {
                durum = "false";
                txtdurum.Text = durum;
            }
            txtortalama.Text = ort.ToString();
            
        }
    }
}
