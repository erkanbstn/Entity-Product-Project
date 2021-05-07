using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityÜrünProje
{
    public partial class FrmÜrünler : Form
    {
        public FrmÜrünler()
        {
            InitializeComponent();
        }

        private void FrmÜrünler_Load(object sender, EventArgs e)
        {
            var kategori = (from y in db.TblKategori select new { y.KategoriID, y.KategoriAd }).ToList();
            cmbkategori.ValueMember = "KategoriID";  //Arkaplanda çalışacak değer
            cmbkategori.DisplayMember = "KategoriAd"; //Gözükecek değer
            cmbkategori.DataSource = kategori;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(txtıd.Text);
            var üg = db.TblÜrün.Find(y);
            üg.ÜrünAd = txtmarka.Text;
            üg.Marka = txtmarka.Text;
            üg.Stok = short.Parse(txtstok.Text);
            üg.Fiyat= decimal.Parse(txtfiyat.Text);
            üg.Kategori =Convert.ToInt32(cmbkategori.Text);
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtıd.Text);
            var üt = db.TblÜrün.Find(x);
            db.TblÜrün.Remove(üt);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtstok.Text = "";
            txtmarka.Text = "";
            txtfiyat.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblÜrün t = new TblÜrün();
            t.ÜrünAd = txtad.Text;
            t.Marka = txtmarka.Text;
            t.Stok = short.Parse(txtstok.Text);
            t.Fiyat = Convert.ToInt32(txtfiyat.Text);
            t.Durum = true;
            t.Kategori = Convert.ToInt32(cmbkategori.SelectedValue.ToString());
            db.TblÜrün.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        DBEntityFrameworkEntities db = new DBEntityFrameworkEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TblÜrün select new 
            { x.ÜrünID, x.ÜrünAd, x.Marka, x.Stok, x.Kategori, x.Fiyat }).ToList();
        }
    }
}
