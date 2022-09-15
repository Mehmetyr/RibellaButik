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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void OpenForm(Form frm)
        {
            Form[] OpenForms = this.MdiChildren;
            bool isopen = false;
            foreach (Form item in OpenForms)
            {
                if (frm.GetType() == item.GetType())
                {
                    isopen = true;
                    item.Activate();
                }
            }
            if (isopen == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void TSMI_KategoriForm_Click(object sender, EventArgs e)
        {
            OpenForm(new KategoriForm());
        }

        private void TSMI_ProductForm_Click(object sender, EventArgs e)
        {
            OpenForm(new ProductForm());
        }

        private void TSMI_BrandForm_Click(object sender, EventArgs e)
        {
            OpenForm(new Brands());
        }
    }
}
