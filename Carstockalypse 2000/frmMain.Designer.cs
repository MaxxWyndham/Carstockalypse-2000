
namespace Carstockalypse_2000
{
    partial class frmMain
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
            this.tlpPanels = new System.Windows.Forms.TableLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.gbAvailable = new System.Windows.Forms.GroupBox();
            this.pbAvailable = new System.Windows.Forms.PictureBox();
            this.txtAvailableDescription = new System.Windows.Forms.TextBox();
            this.lblAvailableDescription = new System.Windows.Forms.Label();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.gbInstalled = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pbInstalled = new System.Windows.Forms.PictureBox();
            this.txtInstalledDescription = new System.Windows.Forms.TextBox();
            this.lblInstalledDescription = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.lstInstalled = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.tlpPanels.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gbAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailable)).BeginInit();
            this.gbInstalled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstalled)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPanels
            // 
            this.tlpPanels.ColumnCount = 3;
            this.tlpPanels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPanels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanels.Controls.Add(this.pnlButtons, 1, 0);
            this.tlpPanels.Controls.Add(this.gbAvailable, 0, 0);
            this.tlpPanels.Controls.Add(this.gbInstalled, 2, 0);
            this.tlpPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanels.Location = new System.Drawing.Point(0, 0);
            this.tlpPanels.Name = "tlpPanels";
            this.tlpPanels.RowCount = 1;
            this.tlpPanels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanels.Size = new System.Drawing.Size(649, 521);
            this.tlpPanels.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnUninstall);
            this.pnlButtons.Controls.Add(this.btnInstall);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(302, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(44, 515);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Enabled = false;
            this.btnUninstall.Location = new System.Drawing.Point(0, 125);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(44, 44);
            this.btnUninstall.TabIndex = 1;
            this.btnUninstall.Text = "←";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(0, 75);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(44, 44);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "→";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // gbAvailable
            // 
            this.gbAvailable.Controls.Add(this.pbAvailable);
            this.gbAvailable.Controls.Add(this.txtAvailableDescription);
            this.gbAvailable.Controls.Add(this.lblAvailableDescription);
            this.gbAvailable.Controls.Add(this.lstAvailable);
            this.gbAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAvailable.Location = new System.Drawing.Point(3, 3);
            this.gbAvailable.Name = "gbAvailable";
            this.gbAvailable.Size = new System.Drawing.Size(293, 515);
            this.gbAvailable.TabIndex = 1;
            this.gbAvailable.TabStop = false;
            this.gbAvailable.Text = "available cars";
            // 
            // pbAvailable
            // 
            this.pbAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbAvailable.Location = new System.Drawing.Point(53, 378);
            this.pbAvailable.Name = "pbAvailable";
            this.pbAvailable.Size = new System.Drawing.Size(192, 128);
            this.pbAvailable.TabIndex = 9;
            this.pbAvailable.TabStop = false;
            // 
            // txtAvailableDescription
            // 
            this.txtAvailableDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvailableDescription.Location = new System.Drawing.Point(9, 261);
            this.txtAvailableDescription.Multiline = true;
            this.txtAvailableDescription.Name = "txtAvailableDescription";
            this.txtAvailableDescription.ReadOnly = true;
            this.txtAvailableDescription.Size = new System.Drawing.Size(282, 111);
            this.txtAvailableDescription.TabIndex = 8;
            // 
            // lblAvailableDescription
            // 
            this.lblAvailableDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAvailableDescription.AutoSize = true;
            this.lblAvailableDescription.Location = new System.Drawing.Point(9, 245);
            this.lblAvailableDescription.Name = "lblAvailableDescription";
            this.lblAvailableDescription.Size = new System.Drawing.Size(58, 13);
            this.lblAvailableDescription.TabIndex = 7;
            this.lblAvailableDescription.Text = "description";
            // 
            // lstAvailable
            // 
            this.lstAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.IntegralHeight = false;
            this.lstAvailable.Location = new System.Drawing.Point(6, 19);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(281, 223);
            this.lstAvailable.TabIndex = 0;
            this.lstAvailable.SelectedIndexChanged += new System.EventHandler(this.lstAvailable_SelectedIndexChanged);
            // 
            // gbInstalled
            // 
            this.gbInstalled.Controls.Add(this.lblVersion);
            this.gbInstalled.Controls.Add(this.pbInstalled);
            this.gbInstalled.Controls.Add(this.txtInstalledDescription);
            this.gbInstalled.Controls.Add(this.lblInstalledDescription);
            this.gbInstalled.Controls.Add(this.btnDown);
            this.gbInstalled.Controls.Add(this.lstInstalled);
            this.gbInstalled.Controls.Add(this.btnUp);
            this.gbInstalled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInstalled.Location = new System.Drawing.Point(352, 3);
            this.gbInstalled.Name = "gbInstalled";
            this.gbInstalled.Size = new System.Drawing.Size(294, 515);
            this.gbInstalled.TabIndex = 2;
            this.gbInstalled.TabStop = false;
            this.gbInstalled.Text = "installed cars";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersion.Location = new System.Drawing.Point(246, 500);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 15);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "v1.0.0.0";
            // 
            // pbInstalled
            // 
            this.pbInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInstalled.Location = new System.Drawing.Point(50, 378);
            this.pbInstalled.Name = "pbInstalled";
            this.pbInstalled.Size = new System.Drawing.Size(192, 128);
            this.pbInstalled.TabIndex = 6;
            this.pbInstalled.TabStop = false;
            // 
            // txtInstalledDescription
            // 
            this.txtInstalledDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstalledDescription.Location = new System.Drawing.Point(6, 261);
            this.txtInstalledDescription.Multiline = true;
            this.txtInstalledDescription.Name = "txtInstalledDescription";
            this.txtInstalledDescription.ReadOnly = true;
            this.txtInstalledDescription.Size = new System.Drawing.Size(282, 111);
            this.txtInstalledDescription.TabIndex = 5;
            this.txtInstalledDescription.Text = "Driver: ERROL\r\nCar: PLACEHOLDER\r\nStrength: 1\r\nCost: 99p\r\nNetwork Availability: ne" +
    "ver\r\nTOP SPEED: 4MPH\r\nKERB WEIGHT: SEVERAL TONS\r\n0-60MPH: INFINITE SECONDS";
            // 
            // lblInstalledDescription
            // 
            this.lblInstalledDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstalledDescription.AutoSize = true;
            this.lblInstalledDescription.Location = new System.Drawing.Point(6, 245);
            this.lblInstalledDescription.Name = "lblInstalledDescription";
            this.lblInstalledDescription.Size = new System.Drawing.Size(58, 13);
            this.lblInstalledDescription.TabIndex = 4;
            this.lblInstalledDescription.Text = "description";
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(244, 125);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(44, 44);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lstInstalled
            // 
            this.lstInstalled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstalled.FormattingEnabled = true;
            this.lstInstalled.IntegralHeight = false;
            this.lstInstalled.Location = new System.Drawing.Point(4, 19);
            this.lstInstalled.Name = "lstInstalled";
            this.lstInstalled.Size = new System.Drawing.Size(234, 223);
            this.lstInstalled.TabIndex = 1;
            this.lstInstalled.SelectedIndexChanged += new System.EventHandler(this.lstInstalled_SelectedIndexChanged);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(244, 75);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(44, 44);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 521);
            this.Controls.Add(this.tlpPanels);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Carstockalypse 2000";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpPanels.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.gbAvailable.ResumeLayout(false);
            this.gbAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvailable)).EndInit();
            this.gbInstalled.ResumeLayout(false);
            this.gbInstalled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstalled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanels;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.GroupBox gbAvailable;
        private System.Windows.Forms.GroupBox gbInstalled;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ListBox lstInstalled;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.PictureBox pbInstalled;
        private System.Windows.Forms.TextBox txtInstalledDescription;
        private System.Windows.Forms.Label lblInstalledDescription;
        private System.Windows.Forms.PictureBox pbAvailable;
        private System.Windows.Forms.TextBox txtAvailableDescription;
        private System.Windows.Forms.Label lblAvailableDescription;
        private System.Windows.Forms.Label lblVersion;
    }
}

