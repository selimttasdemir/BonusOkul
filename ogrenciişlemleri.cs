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
    public partial class ogrenciişlemleri : Form
    {
        public ogrenciişlemleri()
        {
            InitializeComponent();
        }

        string c = " ";

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        DataSet1TableAdapters.tbl_ogrenciTableAdapter ds = new DataSet1TableAdapters.tbl_ogrenciTableAdapter();


        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=BonusOkul;Integrated Security=True");

        private void ogrenciişlemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulup",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KulupAd";
            cmbkulup.ValueMember = "kulupid";
            cmbkulup.DataSource = dt;
            baglanti.Close();
        }
        
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                ds.ogrenciekleme(txtograd.Text, txtogrsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
                txtograd.Clear();
                txtogrid.Clear();
                txtogrsoyad.Clear();
                MessageBox.Show("Öğrenci Ekleme Tamamlandı.!");

            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş!","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

       

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
        }


        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ogrencisil(byte.Parse(txtogrid.Text));
            txtograd.Clear();
            txtogrid.Clear();
            txtogrsoyad.Clear();
            MessageBox.Show("SİLİNDİ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtogrid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtograd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtogrsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Erkek")
                {
                    rberkek.Checked = true;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Kız")
                {
                    rbkiz.Checked = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Alana Tıklama Yaptınız", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.ogrenciguncelle(txtograd.Text,txtogrsoyad.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),c,int.Parse(txtogrid.Text));
            MessageBox.Show("Güncelleme İşlemi Yapıldı.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void rbkiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rberkek.Checked == true)
            {
                c = "Erkek";
            }
            if (rbkiz.Checked == true)
            {
                c = "Kız";
            }
        }

        private void rberkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rberkek.Checked == true)
            {
                c = "Erkek";
            }
            if (rbkiz.Checked == true)
            {
                c = "Kız";
            }
        }

        private void btnarama_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ds.ogrenciaarama(txtarama.Text);
                txtarama.Clear();
            }
            catch (Exception)
            {
                    MessageBox.Show("Kayıt Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtarama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
        }
    }
}
