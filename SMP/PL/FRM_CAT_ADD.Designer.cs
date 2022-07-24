namespace SMP.PL
{
    partial class FRM_CAT_ADD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CAT_ADD));
            this.btn_colse = new DevExpress.XtraEditors.SimpleButton();
            this.lp_title_page = new System.Windows.Forms.Label();
            this.edit_name = new System.Windows.Forms.TextBox();
            this.pic_cover = new DevExpress.XtraEditors.PictureEdit();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_colse
            // 
            this.btn_colse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_colse.ImageOptions.SvgImage")));
            this.btn_colse.Location = new System.Drawing.Point(489, 1);
            this.btn_colse.Name = "btn_colse";
            this.btn_colse.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_colse.Size = new System.Drawing.Size(34, 33);
            this.btn_colse.TabIndex = 1;
            this.btn_colse.Click += new System.EventHandler(this.btn_colse_Click);
            // 
            // lp_title_page
            // 
            this.lp_title_page.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lp_title_page.AutoSize = true;
            this.lp_title_page.Font = new System.Drawing.Font("29LT Bukra Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lp_title_page.ForeColor = System.Drawing.Color.Gray;
            this.lp_title_page.Location = new System.Drawing.Point(183, 30);
            this.lp_title_page.Name = "lp_title_page";
            this.lp_title_page.Size = new System.Drawing.Size(162, 34);
            this.lp_title_page.TabIndex = 5;
            this.lp_title_page.Text = "اسم الصنف";
            // 
            // edit_name
            // 
            this.edit_name.Font = new System.Drawing.Font("29LT Bukra Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_name.Location = new System.Drawing.Point(134, 84);
            this.edit_name.Name = "edit_name";
            this.edit_name.Size = new System.Drawing.Size(256, 34);
            this.edit_name.TabIndex = 6;
            this.edit_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pic_cover
            // 
            this.pic_cover.EditValue = global::SMP.Properties.Resources.category;
            this.pic_cover.Location = new System.Drawing.Point(134, 153);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_cover.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_cover.Size = new System.Drawing.Size(256, 218);
            this.pic_cover.TabIndex = 7;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("29LT Bukra Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(417, 382);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(115, 48);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "اضافة ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // FRM_CAT_ADD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 432);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.edit_name);
            this.Controls.Add(this.lp_title_page);
            this.Controls.Add(this.btn_colse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_CAT_ADD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_colse;
        private System.Windows.Forms.Label lp_title_page;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        public System.Windows.Forms.TextBox edit_name;
        public DevExpress.XtraEditors.PictureEdit pic_cover;
    }
}