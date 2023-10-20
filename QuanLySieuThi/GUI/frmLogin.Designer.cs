namespace GUI
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.chkRememberPS = new ReaLTaiizor.Controls.AloneCheckBox();
            this.cboRole = new ReaLTaiizor.Controls.DungeonComboBox();
            this.btnShowPS = new ReaLTaiizor.Controls.ParrotPictureBox();
            this.txtPS = new ReaLTaiizor.Controls.DungeonTextBox();
            this.moonLabel2 = new ReaLTaiizor.Controls.MoonLabel();
            this.moonLabel1 = new ReaLTaiizor.Controls.MoonLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.btnLogin = new ReaLTaiizor.Controls.Button();
            this.lbError = new ReaLTaiizor.Controls.CrownLabel();
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
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 7);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(498, 498);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.wallpaper_login;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 498);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.lbError);
            this.metroPanel2.Controls.Add(this.chkRememberPS);
            this.metroPanel2.Controls.Add(this.cboRole);
            this.metroPanel2.Controls.Add(this.btnShowPS);
            this.metroPanel2.Controls.Add(this.txtPS);
            this.metroPanel2.Controls.Add(this.moonLabel2);
            this.metroPanel2.Controls.Add(this.moonLabel1);
            this.metroPanel2.Controls.Add(this.bigLabel1);
            this.metroPanel2.Controls.Add(this.btnLogin);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(498, 60);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(502, 445);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // chkRememberPS
            // 
            this.chkRememberPS.BackColor = System.Drawing.Color.White;
            this.chkRememberPS.Checked = false;
            this.chkRememberPS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberPS.EnabledCalc = true;
            this.chkRememberPS.ForeColor = System.Drawing.Color.DimGray;
            this.chkRememberPS.Location = new System.Drawing.Point(285, 294);
            this.chkRememberPS.Name = "chkRememberPS";
            this.chkRememberPS.Size = new System.Drawing.Size(161, 18);
            this.chkRememberPS.TabIndex = 13;
            this.chkRememberPS.Text = "NHỚ MẬT KHẨU";
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.White;
            this.cboRole.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cboRole.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cboRole.ColorC = System.Drawing.Color.White;
            this.cboRole.ColorD = System.Drawing.Color.White;
            this.cboRole.ColorE = System.Drawing.Color.White;
            this.cboRole.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cboRole.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cboRole.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cboRole.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cboRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownHeight = 100;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRole.ForeColor = System.Drawing.Color.DimGray;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cboRole.IntegralHeight = false;
            this.cboRole.ItemHeight = 20;
            this.cboRole.Location = new System.Drawing.Point(193, 143);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(242, 26);
            this.cboRole.StartIndex = 0;
            this.cboRole.TabIndex = 12;
            // 
            // btnShowPS
            // 
            this.btnShowPS.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorLeft = System.Drawing.Color.Transparent;
            this.btnShowPS.ColorRight = System.Drawing.Color.Transparent;
            this.btnShowPS.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.btnShowPS.FilterAlpha = 200;
            this.btnShowPS.FilterEnabled = true;
            this.btnShowPS.Image = global::GUI.Properties.Resources.close_eyes_32;
            this.btnShowPS.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.btnShowPS.IsElipse = false;
            this.btnShowPS.IsParallax = false;
            this.btnShowPS.Location = new System.Drawing.Point(402, 220);
            this.btnShowPS.Name = "btnShowPS";
            this.btnShowPS.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.btnShowPS.Size = new System.Drawing.Size(30, 30);
            this.btnShowPS.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.btnShowPS.TabIndex = 10;
            this.btnShowPS.Tag = "closePS";
            this.btnShowPS.Text = "parrotPictureBox1";
            this.btnShowPS.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // txtPS
            // 
            this.txtPS.BackColor = System.Drawing.Color.Transparent;
            this.txtPS.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtPS.EdgeColor = System.Drawing.Color.White;
            this.txtPS.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPS.ForeColor = System.Drawing.Color.DimGray;
            this.txtPS.Location = new System.Drawing.Point(193, 218);
            this.txtPS.MaxLength = 32767;
            this.txtPS.Multiline = false;
            this.txtPS.Name = "txtPS";
            this.txtPS.ReadOnly = false;
            this.txtPS.Size = new System.Drawing.Size(242, 34);
            this.txtPS.TabIndex = 7;
            this.txtPS.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPS.UseSystemPasswordChar = true;
            // 
            // moonLabel2
            // 
            this.moonLabel2.AutoSize = true;
            this.moonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel2.Location = new System.Drawing.Point(63, 222);
            this.moonLabel2.Name = "moonLabel2";
            this.moonLabel2.Size = new System.Drawing.Size(109, 23);
            this.moonLabel2.TabIndex = 4;
            this.moonLabel2.Text = "MẬT KHẨU:";
            // 
            // moonLabel1
            // 
            this.moonLabel1.AutoSize = true;
            this.moonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.moonLabel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moonLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.moonLabel1.Location = new System.Drawing.Point(63, 146);
            this.moonLabel1.Name = "moonLabel1";
            this.moonLabel1.Size = new System.Drawing.Size(87, 23);
            this.moonLabel1.TabIndex = 4;
            this.moonLabel1.Text = "BẠN LÀ:";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.bigLabel1.Location = new System.Drawing.Point(32, 19);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(432, 93);
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
            this.btnLogin.Location = new System.Drawing.Point(123, 340);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Size = new System.Drawing.Size(263, 66);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbError.Location = new System.Drawing.Point(193, 260);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(129, 16);
            this.lbError.TabIndex = 14;
            this.lbError.Text = "Kiểm tra lại mật khẩu";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 505);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
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
        private ReaLTaiizor.Controls.MoonLabel moonLabel1;
        private ReaLTaiizor.Controls.DungeonTextBox txtPS;
        private ReaLTaiizor.Controls.ParrotPictureBox btnShowPS;
        private ReaLTaiizor.Controls.DungeonComboBox cboRole;
        private ReaLTaiizor.Controls.AloneCheckBox chkRememberPS;
        private ReaLTaiizor.Controls.CrownLabel lbError;
    }
}

