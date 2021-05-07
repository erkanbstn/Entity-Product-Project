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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBEntityFrameworkEntities db = new DBEntityFrameworkEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategori = db.TblKategori.ToList();
            dataGridView1.DataSource = (from x in db.TblKategori select new { x.KategoriID, x.KategoriAd }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            TblKategori t = new TblKategori();
            t.KategoriAd = txtad.Text;
            db.TblKategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtıd.Text);
            var ktg = db.TblKategori.Find(x);
            db.TblKategori.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(txtıd.Text);
            var ktgr = db.TblKategori.Find(y);
            ktgr.KategoriAd = txtad.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
