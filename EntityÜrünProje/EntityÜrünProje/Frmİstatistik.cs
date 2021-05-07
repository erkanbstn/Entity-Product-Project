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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DBEntityFrameworkEntities db = new DBEntityFrameworkEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TblKategori.Count().ToString();
            label3.Text = db.TblÜrün.Count().ToString();
            label5.Text = db.TblMüşteri.Count(x => x.Durum == true).ToString();
            label7.Text = db.TblMüşteri.Count(x => x.Durum == false).ToString();
            label13.Text = db.TblÜrün.Count(x => x.Kategori == 1).ToString();
            label11.Text = db.TblÜrün.Sum(x => x.Stok).ToString();
            //label15.Text = db.TblÜrün.Max(x => x.Fiyat).ToString();
            //label17.Text = db.TblÜrün.Min(x => x.Fiyat).ToString();
            label21.Text = db.TblÜrün.Sum(x => x.Fiyat).ToString();
            label15.Text = (from x in db.TblÜrün orderby x.Fiyat descending select x.ÜrünAd).FirstOrDefault();
            label17.Text = (from x in db.TblÜrün orderby x.Fiyat ascending select x.ÜrünAd).FirstOrDefault();
            label25.Text = db.TblÜrün.Count(x => x.ÜrünAd == "Buzdolabı").ToString();
            label19.Text = (from x in db.TblMüşteri select x.Şehir).Distinct().Count().ToString();
            label23.Text = db.MarkaGetir().FirstOrDefault();

            

        }
    }
}
