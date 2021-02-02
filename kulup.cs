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
    public partial class kulup : Form
    {
        public kulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=BonusOkul;Integrated Security=True");

        public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulup", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void kulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_kulup SET KULUPAD = @P2 where kulupid= @p1", baglanti);
                cmd.Parameters.AddWithValue("@p2", txtkulupadı.Text);
                cmd.Parameters.AddWithValue("@p1", txtkulupid.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme İşlemi  Tamamlandı...!!!");
                liste();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("delete from tbl_kulup where kulupid= @p1", baglanti);
                cmd.Parameters.AddWithValue("@p1", txtkulupid.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi  Tamamlandı...!!!");
                liste();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into tbl_kulup (kulupad) values (@p1)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtkulupadı.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kulüp Listeye Eklendi...", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                liste();
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş Yaptınız...!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtkulupadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Yanlış Satıra Tıklama Yaptınız...!!!","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
