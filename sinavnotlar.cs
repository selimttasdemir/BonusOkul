using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusOkul
{
    public partial class sinavnotlar : Form
    {
        public sinavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notlarTableAdapter ds = new DataSet1TableAdapters.tbl_notlarTableAdapter();
        private void btnarama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                
                
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Alana Tıklama Yaptınız", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=BonusOkul;Integrated Security=True");
        private void sinavnotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_ders", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders.DisplayMember = "DersAd";
            cmbders.ValueMember = "dersid";
            cmbders.DataSource = dt;
            baglanti.Close();
        }

        int sinav1, sinav2, sinav3, proje,notid;
        double ortalama;
        string durum;

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.notguncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtid.Text),byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtdurum.Text),notid);
        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {

            sinav1 = Convert.ToInt16(txtsinav1.Text);
            sinav2 = Convert.ToInt16(txtsinav2.Text);
            sinav3 = Convert.ToInt16(txtsinav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = Convert.ToDouble((sinav1 + sinav2 + sinav3 + proje) / 4);
            txtortalama.Text = ortalama.ToString();
            if (ortalama>=55)
            {
                txtdurum.Text = "Geçti";
            }
            else
            {
                txtdurum.Text = "Kaldı";
            }
        }
    }
}
