namespace UserInput
{
    partial class User_LoginUp
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
            this.components = new System.ComponentModel.Container();
            this.siticoneAnimateWindow1 = new Siticone.UI.WinForms.SiticoneAnimateWindow(this.components);
            this.txtConfirm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSend = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtGmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GmailLbl = new System.Windows.Forms.Label();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.btnConfirm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.CodeLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimerLogin = new System.Windows.Forms.Timer(this.components);
            this.BackBtn = new Siticone.UI.WinForms.SiticoneCircleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PasswordUserBtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label6 = new System.Windows.Forms.Label();
            this.PasswordUserTxt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.showPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConfirm
            // 
            this.txtConfirm.Enabled = false;
            this.txtConfirm.Location = new System.Drawing.Point(95, 487);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.ReadOnly = true;
            this.txtConfirm.Size = new System.Drawing.Size(351, 39);
            this.txtConfirm.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtConfirm.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtConfirm.StateCommon.Border.Rounding = 20;
            this.txtConfirm.StateCommon.Border.Width = 1;
            this.txtConfirm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtConfirm.StateNormal.Border.Rounding = 10;
            this.txtConfirm.StateNormal.Border.Width = 0;
            this.txtConfirm.TabIndex = 24;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(456, 368);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(104, 41);
            this.btnSend.TabIndex = 25;
            this.btnSend.Values.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtGmail
            // 
            this.txtGmail.Location = new System.Drawing.Point(95, 366);
            this.txtGmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtGmail.Name = "txtGmail";
            this.txtGmail.Size = new System.Drawing.Size(353, 39);
            this.txtGmail.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtGmail.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtGmail.StateCommon.Border.Rounding = 20;
            this.txtGmail.StateCommon.Border.Width = 1;
            this.txtGmail.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtGmail.StateNormal.Border.Rounding = 10;
            this.txtGmail.StateNormal.Border.Width = 0;
            this.txtGmail.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 332);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 453);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "Verification Code";
            // 
            // GmailLbl
            // 
            this.GmailLbl.AutoSize = true;
            this.GmailLbl.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GmailLbl.ForeColor = System.Drawing.Color.Red;
            this.GmailLbl.Location = new System.Drawing.Point(96, 412);
            this.GmailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GmailLbl.Name = "GmailLbl";
            this.GmailLbl.Size = new System.Drawing.Size(0, 24);
            this.GmailLbl.TabIndex = 46;
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::UserInput.Properties.Resources.redcircleN3;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed = global::UserInput.Properties.Resources.redcircleN1;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::UserInput.Properties.Resources.redcircleN4;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::UserInput.Properties.Resources.yellowcircleN2;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::UserInput.Properties.Resources.yellowcircleN;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::UserInput.Properties.Resources.greencircleN1;
            this.kryptonPalette1.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::UserInput.Properties.Resources.greencircleN2;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(453, 490);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 41);
            this.btnConfirm.TabIndex = 51;
            this.btnConfirm.Values.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // CodeLbl
            // 
            this.CodeLbl.AutoSize = true;
            this.CodeLbl.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLbl.ForeColor = System.Drawing.Color.Red;
            this.CodeLbl.Location = new System.Drawing.Point(96, 534);
            this.CodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CodeLbl.Name = "CodeLbl";
            this.CodeLbl.Size = new System.Drawing.Size(0, 24);
            this.CodeLbl.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(188, 251);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 58);
            this.label3.TabIndex = 54;
            this.label3.Text = "REGISTER";
            // 
            // TimerLogin
            // 
            this.TimerLogin.Enabled = true;
            this.TimerLogin.Tick += new System.EventHandler(this.TimerLogin_Tick);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Transparent;
            this.BackBtn.BackgroundImage = global::UserInput.Properties.Resources.icons8_go_back_40;
            this.BackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackBtn.CheckedState.Parent = this.BackBtn;
            this.BackBtn.CustomImages.Parent = this.BackBtn;
            this.BackBtn.FillColor = System.Drawing.Color.Transparent;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.HoveredState.Parent = this.BackBtn;
            this.BackBtn.Location = new System.Drawing.Point(16, 708);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.ShadowDecoration.Mode = Siticone.UI.WinForms.Enums.ShadowMode.Circle;
            this.BackBtn.ShadowDecoration.Parent = this.BackBtn;
            this.BackBtn.Size = new System.Drawing.Size(57, 54);
            this.BackBtn.TabIndex = 67;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UserInput.Properties.Resources.Blue_Final_Background_User;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::UserInput.Properties.Resources.ABC_Catering;
            this.pictureBox1.Location = new System.Drawing.Point(-121, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(841, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // PasswordUserBtn
            // 
            this.PasswordUserBtn.Enabled = false;
            this.PasswordUserBtn.Location = new System.Drawing.Point(239, 690);
            this.PasswordUserBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordUserBtn.Name = "PasswordUserBtn";
            this.PasswordUserBtn.Size = new System.Drawing.Size(104, 41);
            this.PasswordUserBtn.TabIndex = 71;
            this.PasswordUserBtn.Values.Text = "Register";
            this.PasswordUserBtn.Click += new System.EventHandler(this.PasswordUserBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 564);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 29);
            this.label6.TabIndex = 69;
            this.label6.Text = "Password";
            // 
            // PasswordUserTxt
            // 
            this.PasswordUserTxt.Enabled = false;
            this.PasswordUserTxt.Location = new System.Drawing.Point(93, 598);
            this.PasswordUserTxt.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordUserTxt.Name = "PasswordUserTxt";
            this.PasswordUserTxt.ReadOnly = true;
            this.PasswordUserTxt.Size = new System.Drawing.Size(351, 39);
            this.PasswordUserTxt.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PasswordUserTxt.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.PasswordUserTxt.StateCommon.Border.Rounding = 20;
            this.PasswordUserTxt.StateCommon.Border.Width = 1;
            this.PasswordUserTxt.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PasswordUserTxt.StateNormal.Border.Rounding = 10;
            this.PasswordUserTxt.StateNormal.Border.Width = 0;
            this.PasswordUserTxt.TabIndex = 68;
            // 
            // showPassword
            // 
            this.showPassword.BackColor = System.Drawing.Color.Transparent;
            this.showPassword.FlatAppearance.BorderSize = 0;
            this.showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassword.Image = global::UserInput.Properties.Resources.eyeclosesmall;
            this.showPassword.Location = new System.Drawing.Point(451, 606);
            this.showPassword.Margin = new System.Windows.Forms.Padding(4);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(48, 28);
            this.showPassword.TabIndex = 72;
            this.showPassword.UseVisualStyleBackColor = false;
            this.showPassword.Click += new System.EventHandler(this.showPassword_Click);
            // 
            // User_LoginUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(599, 775);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.PasswordUserBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PasswordUserTxt);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.CodeLbl);
            this.Controls.Add(this.GmailLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGmail);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtConfirm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "User_LoginUp";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Siticone.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtConfirm;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSend;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label GmailLbl;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConfirm;
        private System.Windows.Forms.Label CodeLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer TimerLogin;
        private Siticone.UI.WinForms.SiticoneCircleButton BackBtn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton PasswordUserBtn;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox PasswordUserTxt;
        public System.Windows.Forms.Button showPassword;
    }
}