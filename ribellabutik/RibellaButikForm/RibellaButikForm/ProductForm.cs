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
    public partial class ProductForm : Form
    {
        RibellaFrom_DbEntities db = new RibellaFrom_DbEntities();
        int secilen;
        public ProductForm()
        {
            InitializeComponent();
        }
        private void GridDoldur()
        {
            dataGridView1.DataSource = (from p in db.Product
                                        select new
                                        {
                                            UrunNo = p.ID,
                                            UrunAdı = p.Name,
                                            Acıklama = p.Description,
                                            Kategori = p.Category.Isim,
                                            Marka = p.Brand.Isim,
                                            Stok = p.Stock,
                                            Fiyat = p.Price,
                                            Tarih = p.CreationDay,
                                            Satis = p.SellStatus == true ? "Satışta Değil" : "Satışta"
                                        }).ToList();
            
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            cb_category.DisplayMember = "Isim";
            cb_category.ValueMember = "ID";
            cb_category.DataSource = db.Category.ToList();

            cb_brand.DisplayMember = "Isim";
            cb_brand.ValueMember = "ID";
            cb_brand.DataSource = db.Brand.ToList();

            GridDoldur();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            Product p = new Product()
            {
                Name = tb_isim.Text,
                Category_ID = Convert.ToInt32(cb_category.SelectedValue.ToString()),
                Brand_ID = Convert.ToInt32(cb_brand.SelectedValue.ToString()),
                Description = tb_Acıklama.Text,
                Stock = Convert.ToDecimal(nud_Stok.Text),
                Price = Convert.ToDecimal(tb_fiyat.Text),
                SellStatus = !cb_durum.Checked,
                CreationDay = DateTime.Now
            };
            try
            {
                db.Product.Add(p);
                db.SaveChanges();
                MessageBox.Show("Ürün " + p.ID + " ile başarıyla eklendi", "Eklendi");
            }
            catch
            {
                MessageBox.Show("Ürün eklenirken bir hata meydana geldi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Product p = db.Product.Find(secilen);
            tb_ID.Text = p.ID.ToString();
            tb_isim.Text = p.Name;
            cb_category.Text = p.Category_ID.ToString();
            cb_brand.Text = p.Brand_ID.ToString();
            tb_Acıklama.Text = p.Description;
            p.Stock = Convert.ToDecimal(nud_Stok.Text);
            p.Price = Convert.ToDecimal(tb_fiyat.Text);
            cb_durum.Checked = false;

        }
    }
}
