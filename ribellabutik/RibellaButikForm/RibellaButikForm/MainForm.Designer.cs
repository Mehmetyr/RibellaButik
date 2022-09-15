
namespace RibellaButikForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ProductForm = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_KategoriForm = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_BrandForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.işlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1457, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kapatToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // kapatToolStripMenuItem
            // 
            this.kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
            this.kapatToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.kapatToolStripMenuItem.Text = "Kapat";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_ProductForm,
            this.TSMI_KategoriForm,
            this.TSMI_BrandForm});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // TSMI_ProductForm
            // 
            this.TSMI_ProductForm.Name = "TSMI_ProductForm";
            this.TSMI_ProductForm.Size = new System.Drawing.Size(224, 26);
            this.TSMI_ProductForm.Text = "Ürün İşlemleri";
            this.TSMI_ProductForm.Click += new System.EventHandler(this.TSMI_ProductForm_Click);
            // 
            // TSMI_KategoriForm
            // 
            this.TSMI_KategoriForm.Name = "TSMI_KategoriForm";
            this.TSMI_KategoriForm.Size = new System.Drawing.Size(224, 26);
            this.TSMI_KategoriForm.Text = "Kategori İşlemleri";
            this.TSMI_KategoriForm.Click += new System.EventHandler(this.TSMI_KategoriForm_Click);
            // 
            // TSMI_BrandForm
            // 
            this.TSMI_BrandForm.Name = "TSMI_BrandForm";
            this.TSMI_BrandForm.Size = new System.Drawing.Size(224, 26);
            this.TSMI_BrandForm.Text = "Marka İşlemleri";
            this.TSMI_BrandForm.Click += new System.EventHandler(this.TSMI_BrandForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 558);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ProductForm;
        private System.Windows.Forms.ToolStripMenuItem TSMI_KategoriForm;
        private System.Windows.Forms.ToolStripMenuItem TSMI_BrandForm;
    }
}