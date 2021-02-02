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
    public partial class dersislemleri : Form
    {
        public dersislemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=BonusOkul;Integrated Security=True");


        DataSet1TableAdapters.tbl_dersTableAdapter ds = new DataSet1TableAdapters.tbl_dersTableAdapter();
        private void dersislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.dersEkle(txtdersadı.Text);
            MessageBox.Show("Ders Ekleme İşlemi Tamamlanmıştır.");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Silme İşlemi Tamamlanmıştır.");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.dersGuncelle(txtdersadı.Text,byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Tamamlanmıştır.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtdersadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Yanlış Satıra Tıklama Yaptınız...!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
