namespace FitnessValleyManager.FORMS
{
    partial class FRM_USERS_PERMISSION
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.CmdClose = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.CmdSave = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ListUsers = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Lists = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DgAutoris = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgAutoris)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Panel1.Controls.Add(this.lblTitle);
            this.Panel1.Controls.Add(this.PictureBox2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(945, 50);
            this.Panel1.TabIndex = 49;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("JF Flat", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(707, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 33);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "صلاحيات المستخدم";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.Image = global::FitnessValleyManager.Properties.Resources.icons8_school_director_48;
            this.PictureBox2.Location = new System.Drawing.Point(898, 6);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(40, 40);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 23;
            this.PictureBox2.TabStop = false;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.bunifuCards1.Controls.Add(this.DgAutoris);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.ListUsers);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.Controls.Add(this.Lists);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.CmdClose);
            this.bunifuCards1.Controls.Add(this.CmdSave);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 50);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(945, 449);
            this.bunifuCards1.TabIndex = 205;
            // 
            // CmdClose
            // 
            this.CmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdClose.CheckedState.Parent = this.CmdClose;
            this.CmdClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdClose.CustomImages.Parent = this.CmdClose;
            this.CmdClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(97)))), ((int)(((byte)(88)))));
            this.CmdClose.Font = new System.Drawing.Font("JF Flat", 10F, System.Drawing.FontStyle.Bold);
            this.CmdClose.ForeColor = System.Drawing.Color.White;
            this.CmdClose.HoveredState.Parent = this.CmdClose;
            this.CmdClose.Image = global::FitnessValleyManager.Properties.Resources.Close_Window;
            this.CmdClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CmdClose.ImageSize = new System.Drawing.Size(16, 16);
            this.CmdClose.Location = new System.Drawing.Point(12, 386);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.ShadowDecoration.Parent = this.CmdClose;
            this.CmdClose.Size = new System.Drawing.Size(164, 25);
            this.CmdClose.TabIndex = 215;
            this.CmdClose.Text = "اعادة تشغيل البرنامج";
            this.CmdClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CmdSave
            // 
            this.CmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdSave.CheckedState.Parent = this.CmdSave;
            this.CmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CmdSave.CustomImages.Parent = this.CmdSave;
            this.CmdSave.Enabled = false;
            this.CmdSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(199)))), ((int)(((byte)(120)))));
            this.CmdSave.Font = new System.Drawing.Font("JF Flat", 10F, System.Drawing.FontStyle.Bold);
            this.CmdSave.ForeColor = System.Drawing.Color.White;
            this.CmdSave.HoveredState.Parent = this.CmdSave;
            this.CmdSave.Image = global::FitnessValleyManager.Properties.Resources.Save_16px;
            this.CmdSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CmdSave.ImageSize = new System.Drawing.Size(16, 16);
            this.CmdSave.Location = new System.Drawing.Point(12, 417);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.ShadowDecoration.Parent = this.CmdSave;
            this.CmdSave.Size = new System.Drawing.Size(164, 25);
            this.CmdSave.TabIndex = 213;
            this.CmdSave.Text = "حفظ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("JF Flat", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 221;
            this.label1.Text = "قائمة المستخدمين";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ListUsers
            // 
            this.ListUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListUsers.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListUsers.FormattingEnabled = true;
            this.ListUsers.ItemHeight = 28;
            this.ListUsers.Location = new System.Drawing.Point(12, 37);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(191, 340);
            this.ListUsers.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("JF Flat", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(788, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 28);
            this.label4.TabIndex = 219;
            this.label4.Text = "القائمة الأساسية";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lists
            // 
            this.Lists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lists.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lists.FormattingEnabled = true;
            this.Lists.ItemHeight = 28;
            this.Lists.Location = new System.Drawing.Point(747, 39);
            this.Lists.Name = "Lists";
            this.Lists.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lists.Size = new System.Drawing.Size(191, 340);
            this.Lists.TabIndex = 218;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("JF Flat", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(396, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 28);
            this.label3.TabIndex = 216;
            this.label3.Text = "صلاحيات المستخدم";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DgAutoris
            // 
            this.DgAutoris.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DgAutoris.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgAutoris.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgAutoris.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgAutoris.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgAutoris.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgAutoris.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgAutoris.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("JF Flat", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgAutoris.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgAutoris.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("JF Flat", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgAutoris.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgAutoris.EnableHeadersVisualStyles = false;
            this.DgAutoris.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgAutoris.Location = new System.Drawing.Point(209, 41);
            this.DgAutoris.MultiSelect = false;
            this.DgAutoris.Name = "DgAutoris";
            this.DgAutoris.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgAutoris.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgAutoris.RowHeadersVisible = false;
            this.DgAutoris.RowTemplate.DividerHeight = 5;
            this.DgAutoris.RowTemplate.Height = 40;
            this.DgAutoris.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgAutoris.Size = new System.Drawing.Size(532, 336);
            this.DgAutoris.TabIndex = 222;
            this.DgAutoris.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DgAutoris.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DgAutoris.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DgAutoris.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DgAutoris.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DgAutoris.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DgAutoris.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgAutoris.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgAutoris.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.DgAutoris.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgAutoris.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("JF Flat", 9F);
            this.DgAutoris.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.DgAutoris.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DgAutoris.ThemeStyle.HeaderStyle.Height = 40;
            this.DgAutoris.ThemeStyle.ReadOnly = true;
            this.DgAutoris.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DgAutoris.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgAutoris.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("JF Flat", 10.5F);
            this.DgAutoris.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DgAutoris.ThemeStyle.RowsStyle.Height = 40;
            this.DgAutoris.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(143)))), ((int)(((byte)(199)))));
            this.DgAutoris.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // FRM_USERS_PERMISSION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 499);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FRM_USERS_PERMISSION";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "FRM_USERS_PERMISSION";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgAutoris)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ListUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox Lists;
        private System.Windows.Forms.Label label3;
        private Siticone.UI.WinForms.SiticoneRoundedButton CmdClose;
        private Siticone.UI.WinForms.SiticoneRoundedButton CmdSave;
        private Guna.UI2.WinForms.Guna2DataGridView DgAutoris;
    }
}