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
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }
        DBEntityFrameworkEntities db = new DBEntityFrameworkEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TblAdmin where x.Kullanıcı == textBox1.Text && x.Şifre==textBox2.Text select x;
            if (sorgu.Any())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
