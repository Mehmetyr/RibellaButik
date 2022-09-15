using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RibellaButikForm
{
    public partial class KategoriForm : Form
    {
        RibellaFrom_DbEntities db = new RibellaFrom_DbEntities();
        int secilen;
        public KategoriForm()
        {
            InitializeComponent();
        }

        private void GridDoldur()
        {
            dataGridView1.DataSource = (from c in db.Category
                                        select new
                                        {
                                            KategoriID = c.ID,
                                            KategoriAdı = c.Isim,
                                            Açıklama = c.Description,
                                            Durum = c.Status == true ? "Aktif " : "Aktif Değil"

                                        }).ToList();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            Category c = new Category()
            {
                Isim = tb_kategoriİsim.Text,
                Description = tb_kategoriAcıklama.Text,
                Status = cb_statuss.Checked
            };
            try
            {
                db.Category.Add(c);
                db.SaveChanges();
                MessageBox.Show("Kategori " + c.ID + " id ile başarıyla eklenmiştir", "Eklendi");
            }
            catch
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GridDoldur();
        }

        private void KategoriForm_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.ClearSelection();
                    if (hit.RowIndex != -1)
                    {
                        dataGridView1.Rows[hit.RowIndex].Selected = true;
                        contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                        secilen = Convert.ToInt32(dataGridView1.Rows[hit.RowIndex].Cells[0].Value);
                    }
                }
            
        }

        private void TSMI_Güncelle_Click(object sender, EventArgs e)
        {
            Category c = db.Category.Find(secilen);
            tb_ID.Text = c.ID.ToString();
            tb_kategoriİsim.Text = c.Isim;
            tb_kategoriAcıklama.Text = c.Description;
            cb_statuss.Checked = false;
            btn_ekle.Enabled = false;
            btn_update.Enabled = true;
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            
                Category c = db.Category.Find(secilen);
                c.Isim = tb_kategoriİsim.Text;
                c.Description = tb_kategoriAcıklama.Text;
                c.Status = cb_statuss.Checked;
                try
                {
                    db.SaveChanges();
                    btn_ekle.Enabled = true;
                    btn_update.Enabled = false;


                }
                catch
                {
                    MessageBox.Show("Ürün güncellenirken bir hat oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                GridDoldur();
        
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_ID.Text = "";
            tb_kategoriİsim.Text = "";
            tb_kategoriAcıklama.Text= "";

        }

        private void TSMI_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                Category c = db.Category.Find(secilen);
                db.Category.Remove(c);
                db.SaveChanges();
            }
            catch
            {

                MessageBox.Show("Hata oluştu", "Hata");
            }
            GridDoldur();
        }
    }
    
}
