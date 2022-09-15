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
    public partial class Brands : Form
    {
        RibellaFrom_DbEntities db = new RibellaFrom_DbEntities();
        int secilen;
        public Brands()
        {
            InitializeComponent();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = (from b in db.Brand
                                        select new
                                        {
                                            MarkaID = b.ID.ToString(),
                                            MarkaIsim = b.Isim,
                                            Durum = b.Status == true ? "Aktif" : "Aktif Değil"
                                        }).ToList();
        }

        private void Brands_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            Brand b = new Brand()
            {
                Isim = tb_Isim.Text,
                Status = cb_Durum.Checked

            };
            try
            {
                db.Brand.Add(b);
                db.SaveChanges();
                MessageBox.Show("Kategori " + b.ID + " id ile başarıyla eklenmiştir", "Eklendi");
            }
            catch 
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void TSMI_Guncelle_Click(object sender, EventArgs e)
        {
            Brand b = db.Brand.Find(secilen);
            tb_ID.Text = b.ID.ToString();
            tb_Isim.Text = b.Isim;
            cb_Durum.Checked = false;
            btn_Ekle.Enabled = false;
            btn_Guncelle.Enabled = true;
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Brand b = db.Brand.Find(secilen);
            b.Isim = tb_Isim.Text;
            b.Status = cb_Durum.Checked;
            try
            {
                db.SaveChanges();
                btn_Ekle.Enabled = true;
                btn_Guncelle.Enabled = false;
            }
            catch 
            {

                MessageBox.Show("Ürün güncellenirken bir hat oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btn_sıfırla_Click(object sender, EventArgs e)
        {
            tb_ID.Text = "";
            tb_Isim.Text = "";
        }

        private void TSMI_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                Brand b = db.Brand.Find(secilen);
                db.Brand.Remove(b);
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
