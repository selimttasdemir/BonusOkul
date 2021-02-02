using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusOkul
{
    public partial class ogretmen : Form
    {
        public ogretmen()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            kulup klp = new kulup();
            this.Hide();
            klp.Show();

        }

        private void btndersislemleri_Click(object sender, EventArgs e)
        {
            dersislemleri ders = new dersislemleri();
            this.Hide();
            ders.Show();
        }

        private void btnogrenciislem_Click(object sender, EventArgs e)
        {
            ogrenciişlemleri oi = new ogrenciişlemleri();
            this.Hide();
            oi.Show();
        }

        private void btnsınavnotu_Click(object sender, EventArgs e)
        {
            sinavnotlar sn = new sinavnotlar();
            this.Hide();
            sn.Show();
        }
    }
}
