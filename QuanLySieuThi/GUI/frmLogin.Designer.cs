﻿namespace GUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lbError = new ReaLTaiizor.Controls.CrownLabel();
            this.chkRememberPS = new ReaLTaiizor.Controls.AloneCheckBox();
            this.moonLabel2 = new ReaLTaiizor.Controls.MoonLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.btnLogin = new ReaLTaiizor.Controls.Button();
            this.cboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPS = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnShowPS = new ReaLTaiizor.Controls.ParrotPictureBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(0, 6);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(374, 405);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(374, 405);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.btnShowPS);
            this.metroPanel2.Controls.Add(this.txtPS);
            this.metroPanel2.Controls.Add(this.cboRole);
            this.metroPanel2.Controls.Add(this.lbError);
            this.metroPanel2.Controls.Add(this.chkRememberPS);
            this.metroPanel2.Controls.Add(this.moonLabel2);
            this.metroPanel2.Controls.Add(this.bigLabel1);
            this.metroPanel2.Controls.Add(this.btnLogin);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 8;
            this.metroPanel2.Location = new System.Drawing.Point(373, 49);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(416, 361);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 8;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(145, 211);
            this.lbError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 14;
            // 
            // chkRememberPS
            // 
            this.chkRememberPS.BackColor = System.Drawing.Color.White;
            this.chkRememberPS.Checked = false;
            this.chkRememberPS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberPS.EnabledCalc = true;
            this.chkRememberPS.ForeColor = System.Drawing.Color.DimGray;
            this.chkRememberPS.Location = new System.Drawing.Point(277, 239);
            this.chkRememberPS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkRememberPS.Name = "chkRememberPS";
            this.chkRememberPS.Size = new System.Drawing.Size(121, 18);
            this.chkRememberPS.TabIndex = 13;
            this.chkRememberPS.Text = "NHỚ MẬT KHẨU";
            // 
            // moonLabel2
            // 
            this.moonLabel2.AutoSize = true;
            this.moonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel2.Location = new System.Drawing.Point(47, 182);
            this.moonLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.moonLabel2.Name = "moonLabel2";
            this.moonLabel2.Size = new System.Drawing.Size(90, 19);
            this.moonLabel2.TabIndex = 4;
            this.moonLabel2.Text = "MẬT KHẨU:";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bigLabel1.Location = new System.Drawing.Point(49, 15);
            this.bigLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(347, 77);
            this.bigLabel1.TabIndex = 3;
            this.bigLabel1.Text = "WELCOME";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.EnteredBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.EnteredColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Image = null;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.InactiveColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLogin.Location = new System.Drawing.Point(121, 276);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Size = new System.Drawing.Size(197, 54);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.Transparent;
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboRole.ForeColor = System.Drawing.Color.DimGray;
            this.cboRole.ItemHeight = 30;
            this.cboRole.Location = new System.Drawing.Point(51, 112);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(332, 36);
            this.cboRole.TabIndex = 15;
            // 
            // txtPS
            // 
            this.txtPS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPS.DefaultText = "";
            this.txtPS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPS.ForeColor = System.Drawing.Color.DimGray;
            this.txtPS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPS.Location = new System.Drawing.Point(151, 171);
            this.txtPS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPS.Name = "txtPS";
            this.txtPS.PasswordChar = '\0';
            this.txtPS.PlaceholderText = "";
            this.txtPS.SelectedText = "";
            this.txtPS.Size = new System.Drawing.Size(232, 37);
            this.txtPS.TabIndex = 16;
            // 
            // btnShowPS
            // 
            this.btnShowPS.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorLeft = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorRight = System.Drawing.Color.Transparent;
            this.btnShowPS.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.btnShowPS.FilterAlpha = 200;
            this.btnShowPS.FilterEnabled = true;
            this.btnShowPS.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPS.Image")));
            this.btnShowPS.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.btnShowPS.IsElipse = false;
            this.btnShowPS.IsParallax = false;
            this.btnShowPS.Location = new System.Drawing.Point(346, 173);
            this.btnShowPS.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowPS.Name = "btnShowPS";
            this.btnShowPS.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.btnShowPS.Size = new System.Drawing.Size(33, 33);
            this.btnShowPS.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.btnShowPS.TabIndex = 17;
            this.btnShowPS.Tag = "closePS";
            this.btnShowPS.Text = "parrotPictureBox1";
            this.btnShowPS.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 410);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(0, 49, 0, 0);
            this.Text = "                  ";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private ReaLTaiizor.Controls.Button btnLogin;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.MoonLabel moonLabel2;
        private ReaLTaiizor.Controls.AloneCheckBox chkRememberPS;
        private ReaLTaiizor.Controls.CrownLabel lbError;
        private Guna.UI2.WinForms.Guna2ComboBox cboRole;
        private ReaLTaiizor.Controls.ParrotPictureBox btnShowPS;
        private Guna.UI2.WinForms.Guna2TextBox txtPS;
    }
}

